using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class Block : MonoBehaviour
{
    // config params
    [SerializeField] int points;
    [SerializeField] AudioClip[] clip;
    [SerializeField] GameObject blockSparklesVFX;
    //[SerializeField] int maxHits;
    [SerializeField] Sprite[] hitSprites;

    // cached reference
    Vector3 blockPos;
    Level level;
    GameState gameState;
    Scene currentScene;

    // state variables
    [SerializeField] int timesHit; //TODO Only serialised for debugging purposes

    private void Start()
    {

        gameState = FindObjectOfType<GameState>();
        currentScene = SceneManager.GetActiveScene();
        CountBreakableBlocks();

    }

    private void CountBreakableBlocks()
    {
        if (!((currentScene.buildIndex == 0) || (currentScene.buildIndex == SceneManager.sceneCountInBuildSettings - 1)))
        {
            level = FindObjectOfType<Level>();
            if (CompareTag("Breakable"))
            {
                level.CountBlocks();
            }

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (CompareTag("Breakable"))
        {
            HandleHit();
        }

    }

    private void HandleHit()
    {
        timesHit++;
        int maxHits = hitSprites.Length + 1;
        if (timesHit >= maxHits)
        {
            DestroyBlock();
        }
        else
        {
            ShowNextHitSprite();
        }
    }

    private void ShowNextHitSprite()
    {
        int spriteIndex = timesHit - 1;
        if ((hitSprites[spriteIndex]) != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.Log("Block sprite is missing from array: " + gameObject.name);
        }
    }

    private void DestroyBlock()
    {
        Destroy(gameObject);
        //Debug.Log(collision.gameObject.name);
        AddPoints();
        PlayAudio();
        TriggerSparksVFX();
        level.RemoveBreakableBlock();
    }

    // Engine will call the Method when collision happened. it will look for a parameter type Collision 2D

    private void AddPoints()
    {
        
        gameState.AddScore(points);
    }

    private void PlayAudio()
    {
        AudioClip myAudioClip = clip[UnityEngine.Random.Range(0, clip.Length)];
        blockPos = transform.position;
        AudioSource.PlayClipAtPoint(myAudioClip, blockPos);
    }
    private void TriggerSparksVFX()
    {
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 1f);
    }
}
