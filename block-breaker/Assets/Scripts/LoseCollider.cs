using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class LoseCollider : MonoBehaviour
{
    [SerializeField] SceneLoader SceneLoader;

    Level level;

    private void Start()
    {
        level = FindObjectOfType<Level>();

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!level.CheckClearLevel())
        {
            SceneLoader.LoadEndScene();
            level.ResetBreakableBlock();
            level.StopResetScene();
            //SceneManager.LoadScene("EndScene"); <- not recommended
        }



    }

}
