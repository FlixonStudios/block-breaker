using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBlock : MonoBehaviour
{
    GameState gameState;
    [SerializeField] float timeFactor;
    [SerializeField] float timeDuration;
    bool isActive = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        SlowTime();
        
    }
    public void SlowTime()
    {
        gameState = FindObjectOfType<GameState>();
        gameState.AdjustSpeed(timeFactor, timeDuration);
        isActive = true;
    }


}
