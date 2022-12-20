using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class TimerManager : MonoBehaviour
{
    float timeNow = 0;

    //[SerializeField] TMP_Text textTime;
    public TextMeshProUGUI textTime;
    public float startTime = 0;
    public float endTime = 0;
    public bool isCountUp = true;
    public bool infiniteCount = false;
    public bool isFinish = false;

    // Start is called before the first frame update
    void Start()
    {
        timeNow = startTime;
    }

    // Update is called once per frame
    void Update()
    {
        // update time
        if (!isFinish)
        {
            if (isCountUp)
            {
                timeNow += Time.deltaTime;
            }
            else
            {
                timeNow -= Time.deltaTime;
            }
        }
        else
        {
            SceneManager.LoadScene("GameOver");
        }

        //display text
        displayTime(timeNow);

        if (!infiniteCount)
        {
            if (isCountUp && timeNow > endTime)
            {
                isFinish = true;
            }
            else if (!isCountUp && timeNow < endTime)
            {
                isFinish = true;
            }
        }
    }

    void displayTime(float time)
    {
        float minute = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);

        textTime.text = string.Format("Time: {0:00}:{1:00}", minute, seconds);
    }
}
