using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [SerializeField] TMPro.TextMeshProUGUI levelComponent;
    
    [SerializeField] int breakableBlocks; //serialized for debugging purposes

    Level level; bool pauseLoadNextScene = false;
    SceneLoader sceneloader;
    ClearStage clearStageText;

    string str_text = "<error>", str_level;
    
    public static int totalBlockCount = 0;
    Scene currentScene; Level endLevel;

    private void Start()
    {
        ResetNextScene();
        //levelComponent.gameObject.SetActive(true);
        //clearComponent.gameObject.SetActive(false);

        clearStageText = FindObjectOfType<ClearStage>();

        sceneloader = FindObjectOfType<SceneLoader>();
        currentScene = SceneManager.GetActiveScene();

    }
    private void Update()
    {
        //sceneloader = FindObjectOfType<SceneLoader>();
        CheckCurrLevel();
        CheckClearLevel();
        //
    }
    private void CheckCurrLevel()
    {
        if (!((currentScene.buildIndex == 0) || (currentScene.buildIndex == SceneManager.sceneCountInBuildSettings - 1)))
        {
            str_text = levelComponent.text.ToString();
            levelComponent.gameObject.SetActive(true);
            str_level = SceneManager.GetActiveScene().name;
            str_level = str_level.Substring(str_level.LastIndexOf(" ") + 1);
            str_text = str_text.Remove(7);
            levelComponent.text = string.Concat(str_text, str_level);
        }
        
        

        Debug.Log(breakableBlocks);
        Debug.Log(pauseLoadNextScene);
        Debug.Log(CheckClearLevel());
    }
    public bool CheckClearLevel()
    {
        if (breakableBlocks==0) //&& pauseLoadNextScene == false)
        {
            if(pauseLoadNextScene == false)
            {
                ShowClearLevel();
                StartCoroutine(PauseForRead());
                ResetBreakableBlock();
                pauseLoadNextScene = true;
                
            }
            return true;
        }
        else
        {
            pauseLoadNextScene = false;
            return false;
        }
        
    }
    public void CountBlocks()
    {
        breakableBlocks++;
    }
    public void RemoveBreakableBlock()
    {
        breakableBlocks--;
    }
    public void ResetBreakableBlock()
    {
        breakableBlocks = 0;
        //pauseLoadNextScene = false;
    }
    public void ResetNextScene()
    {
        pauseLoadNextScene = false;
    }
    public void StopResetScene()
    {
        pauseLoadNextScene = true;
    }
    IEnumerator PauseForRead()
    {
        yield return new WaitForSeconds(2);
        HideClearLevel();
        sceneloader.LoadNextScene();
        
    }
    private void ShowClearLevel()
    {        
        clearStageText.ShowClearText(true);
    }
    private void HideClearLevel()
    {
        clearStageText.ShowClearText(false);
    }
}
