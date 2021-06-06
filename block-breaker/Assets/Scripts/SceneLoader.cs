using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
    //public NumberWizard receiveScene;
    Level level; GameState gameState;
    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        gameState = FindObjectOfType<GameState>();

        /*if (!((currentSceneIndex == SceneManager.sceneCountInBuildSettings-1) || (currentSceneIndex == 0)))
        {
            level = FindObjectOfType<Level>();
            level.ResetBreakableBlock();
        }*/            
        
        if (currentSceneIndex + 1 == SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(0);
            gameState.ResetScore();    
        }
        else
        {
            SceneManager.LoadScene(currentSceneIndex + 1);        
        }

        
        

    }
    //we created a public method. so now we need to tell something to call it
    //under the Button "On click()", we should drag the GameObject we tied this class to, to the field under the runtime only
    
    public void LoadEndScene()
    {
        SceneManager.LoadScene(SceneManager.sceneCountInBuildSettings - 1);
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }
}
