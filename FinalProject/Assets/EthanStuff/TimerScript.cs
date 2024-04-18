using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    public float timeLeft = 180;
    // Update is called once per frame
    void Update()
    {
        if (timeLeft >= 0) {
            timeLeft -= Time.deltaTime;
        }
        else if (timeLeft < 0){
            timeLeft = 0;
        }
        float minutes = Mathf.FloorToInt(timeLeft / 60);
        float seconds = Mathf.FloorToInt(timeLeft % 60);
        timerText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }
}
