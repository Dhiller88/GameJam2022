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
    float timeLeft = 60f;
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
        timeDisplay.text = temp.ToString();
        if (timeLeft < 0)
        {
            // Need a method to automatically move us to the next area.
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
