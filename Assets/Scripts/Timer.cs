using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// The purpose of this script is to handle the counting down timer function
// It needs to start when the intro example is handled
// When it runs out of time, it needs to make a call 
//     to the Gameplay Script to go to the Conclusion Page

public class Timer : MonoBehaviour
{
    [SerializeField] float timeLeft = 120f;
    [SerializeField] TextMeshProUGUI timeDisplay;
    bool started = false;

    // Start is called before the first frame update
    void Awake()
    {
        SetUpSingleton();
    }

    private void SetUpSingleton()
    {
        int number = FindObjectsOfType<Timer>().Length;
        if (number > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Passing()
    {
        timeLeft -= Time.deltaTime;
        float temp = Mathf.Floor(timeLeft);
        int minute = ((int)timeLeft)/60;
        int second = ((int)timeLeft)%60;
        string secondDisplay = "";
        if (second < 10)
        {
            secondDisplay = "0" + second.ToString();
        }
        else
        {
            secondDisplay = second.ToString();
        }
        string displayThis = minute.ToString() + ":" + secondDisplay; 
        timeDisplay.text = displayThis;
        if (timeLeft < 0)
        {
            FindObjectOfType<GamePlay>().EndInspection();
            Destroy(gameObject);
        }
    }

    public void ResetTime()
    {
        gameObject.SetActive(false);
        Destroy(gameObject);
    }

    public void BeginTime()
    {
        timeDisplay.text = timeLeft.ToString();
        started = true;
    }

    public void PauseTime()
    {
        started = (!started);
    }

    private void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if (started)
        {
            Passing();
        }
    }
}
