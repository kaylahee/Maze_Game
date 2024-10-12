using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeUI : MonoBehaviour
{
    public float totalTime = 60f;
    private float remainingTime;

    public Text timerText;
    public GameObject GameOverPanel;

    // Start is called before the first frame update
    void Start()
    {
        remainingTime = totalTime;
        UpdateTimerText();
    }

    // Update is called once per frame
    void Update()
    {
        remainingTime -= Time.deltaTime;

        if (remainingTime <= 0f)
		{
            remainingTime = 0f;
            //시간이 다 지나면 게임 종료
            GameOverPanel.SetActive(true);
        }

        UpdateTimerText();
    }

    void UpdateTimerText()
	{
        int minutes = Mathf.FloorToInt(remainingTime / 60f);
        int seconds = Mathf.FloorToInt(remainingTime % 60f);
        timerText.text = "Time: " + minutes.ToString("00") + ":" + seconds.ToString("00");
    }

    public void IncreaseTime(float amount)
	{
        if (remainingTime + amount <= totalTime)
        {
            remainingTime += amount;
        }
	}
}
