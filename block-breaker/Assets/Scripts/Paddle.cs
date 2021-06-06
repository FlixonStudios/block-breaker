using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] Sprite sprite;
    float mouseXPos, sprite_wt;
    GameState gameState;
    Ball ball;
    // Start is called before the first frame update
    void Start()
    {
        sprite_wt = sprite.rect.width/100;
        gameState = FindObjectOfType<GameState>();
        ball = FindObjectOfType<Ball>();
        //sprite_ht = sprite.rect.height;
    }

    // Update is called once per frame
    void Update()
    {
        //mouseXPos = Input.mousePosition.x / Screen.width * screenWidthInUnits;
        //Screen width is 16 units (seet at 100 pixels per unit)
        // Vector2 is a covenient class to store x, y postions
        // Declare this variable as a new Vector class
        Vector2 paddlePos = new Vector2(mouseXPos, transform.position.y);
        
        paddlePos.x = Mathf.Clamp(GetXPos(), sprite_wt/2, screenWidthInUnits - sprite_wt/2);
        //Debug.Log(paddlePos.x);
        transform.position = paddlePos;
        //script is currently a component of the paddle, and within paddle there is a transform component, 
        //we are changing the value of the transform of the paddle by assigning it a new value paddlePos
        // 
    }

    private float GetXPos()
    {
        if (gameState.IsAutoPlayEnabled())
        {
            return ball.transform.position.x;
        }
        else
        {
            return Input.mousePosition.x / Screen.width * screenWidthInUnits;
        }
    }
}
