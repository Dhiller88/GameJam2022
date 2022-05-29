using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// The purpose of this script is to check the answer against the intended answer.
// If the answer is correct, move it to the correct ending screen.
// If the answer if incorrect, move it to the incorrect ending screen.

public class Conclusion : MonoBehaviour
{

    [SerializeField] AudioClip SuccessSound;
    [SerializeField] AudioClip FailureSound;
    [SerializeField] Dropdown MurdererDropdown;
    [SerializeField] Dropdown WeaponDropdown;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private bool CheckAnswer(string suspect, string weapon, string motive)
    {
        bool res = true;
        return true;
    }

    public void EndingPlay(string suspect, string weapon, string motive)
    {
        bool res = CheckAnswer(suspect, weapon, motive);
        if (res)
        {
            // Send it to the good ending
        }
        else if (!res)
        {
            // Send it to the bad ending
        }
        else
        {
            Debug.LogError("Error in the Ending Play Method");
        }
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void LoadGame()
    {
        SceneManager.LoadScene(1);
    }
}
