using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] TMPro.TextMeshProUGUI timeText;
    string str_time;
    public float timeLeft = 300.0f;


    // Update is called once per frame
    void Update()
    {
        if (timeLeft < 0)
        {
            timeLeft = 0;
        }
        else
        {
            timeLeft -= Time.deltaTime;
        }
        str_time = timeText.text.ToString();

        str_time = str_time.Remove(6);

        timeText.text = string.Concat(str_time, Mathf.RoundToInt(timeLeft).ToString());
        
        if (timeLeft < 0)
        {
            //Do something;
        }
    }
}
