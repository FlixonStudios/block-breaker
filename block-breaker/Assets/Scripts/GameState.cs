using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameState : MonoBehaviour
{
    [Range(0.1f,2f)][SerializeField] float gameSpeed = 1f;
    float currentGameSpeed, timeDuration;
    [SerializeField] TMPro.TextMeshProUGUI pointsComponent;
    [SerializeField] TMPro.TextMeshProUGUI levelComponent;
    [SerializeField] TMPro.TextMeshProUGUI timeComponent;
    [SerializeField] TMPro.TextMeshProUGUI titleComponent;
    [SerializeField] int currScore;
    [SerializeField] bool isAutoPlayEnabled;
    Scene currScene;
    string pointsString;
    bool isActive = false;

    private void Start()
    {
        currentGameSpeed = gameSpeed;
    }

    void Update()
    {
        currScene = SceneManager.GetActiveScene();
        Time.timeScale = currentGameSpeed;
        UpdateScore();
        CheckUI();
        
        if (isActive == true)
        {
            if (timeDuration < 0)
            {
                timeDuration = 0;
                ResetSpeed();
                isActive = false;
            }
            else
            {
                timeDuration -= Time.deltaTime;
            }
        }
    }

    private void CheckUI()
    {
        if ((currScene.buildIndex == 0) || (currScene.buildIndex == SceneManager.sceneCountInBuildSettings - 1))
        {
            ShowUI(false);
        }
        else
        {
            ShowUI(true);
        }
    }

    public void AdjustSpeed(float timeFactor, float duration)
    {
        currentGameSpeed = timeFactor;
        timeDuration = duration;
        isActive = true;
    }
    public void ResetSpeed()
    {
        currentGameSpeed = gameSpeed;
    }

    public void AddScore(int blockPoint)
    {
        currScore += blockPoint;
    }
    public void UpdateScore()
    {
        pointsString = pointsComponent.text.ToString();
        pointsString = pointsString.Remove(5);
        pointsString = string.Concat(pointsString, currScore).ToString();
        pointsComponent.text = pointsString;

        //Debug.Log(pointsComponent.text);
        //print the thing that collides
        
    }

    public void ResetScore()
    {
        currScore = 0;
    }    
    public void ShowUI(bool isShown)
    {
        if (isShown)
        {
            pointsComponent.gameObject.SetActive(true);
            timeComponent.gameObject.SetActive(true);
            titleComponent.gameObject.SetActive(true);
            levelComponent.gameObject.SetActive(true);
        }
        else
        {
            pointsComponent.gameObject.SetActive(false);
            timeComponent.gameObject.SetActive(false);
            titleComponent.gameObject.SetActive(false);
            levelComponent.gameObject.SetActive(false);
        }
    }
    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameState>().Length;
        //currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        currScene = SceneManager.GetActiveScene();
        
        //if ((gameStatusCount>1) || (currentSceneIndex == 0) || (currentSceneIndex == SceneManager.sceneCountInBuildSettings-1))
        if ((gameStatusCount > 1))
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    public bool IsAutoPlayEnabled()
    {                
        return isAutoPlayEnabled;
       
    }
}
