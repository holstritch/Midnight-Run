using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PeeTimer : MonoBehaviour
{
    public Slider timerSlider;
    public float gameTime;
    private bool _stopTimer;

    private void Start()
    {
        _stopTimer = false;
        timerSlider.maxValue = gameTime;
        timerSlider.value = gameTime;
    }

    private void Update()
    {
        float time = gameTime - Time.time;

        int minutes = Mathf.FloorToInt(time / 20);
        int seconds = Mathf.FloorToInt(time - minutes * 20f);

        if (time <= 0)
        {
            stopTimer = true;
        }

        if (stopTimer == false)
        {
            timerSlider.value = time;
        }
    }
}
