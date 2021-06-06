using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClearStage : MonoBehaviour
{

    TextMeshProUGUI clearText;
    bool isShown;

    private void Start()
    {
        clearText = GetComponent<TextMeshProUGUI>();
        clearText.gameObject.SetActive(false);
    }
    public void ShowClearText(bool isShown)
    {
        clearText = GetComponent<TextMeshProUGUI>();
        if (isShown)
        {
            clearText.gameObject.SetActive(true);
        }
        else
        {
            clearText.gameObject.SetActive(false);
        }
    }
    
}
