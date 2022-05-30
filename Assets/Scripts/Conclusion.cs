using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

// The purpose of this script is to check the answer against the intended answer.
// If the answer is correct, move it to the correct ending screen.
// If the answer if incorrect, move it to the incorrect ending screen.

public class Conclusion : MonoBehaviour
{
    [SerializeField] GameObject ConclusionCanvas;
    [SerializeField] GameObject EndingCanvas;
    [SerializeField] AudioClip SuccessSound;
    [SerializeField] AudioClip FailureSound;
    [SerializeField] TMP_Dropdown weaponDropdown;
    [SerializeField] TMP_Dropdown murdererDropdown;
    [SerializeField] [Range (0,1f)] float volume;

    private string selectedMurderer;
    private string selectedWeapon;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ReturnWeaponSelection()
    {
        selectedWeapon = weaponDropdown.options[weaponDropdown.value].text;
    }
    private void ReturnMurdererSelection()
    {
        selectedMurderer = murdererDropdown.options[murdererDropdown.value].text;
    }



    public bool CheckAnswer()
    {
        ReturnWeaponSelection();
        ReturnMurdererSelection();
        if(selectedMurderer == "David" && selectedWeapon == "Almonds")
        {
        bool res = true;
        return true;
        }
        else
        {
            return false;
        }
    }

    public void EndingPlay()
    {
        bool res = CheckAnswer();
        if (res)
        {
            // Send it to the good ending
            ConclusionCanvas.gameObject.SetActive(false);
            EndingCanvas.gameObject.SetActive(true);
            AudioSource.PlayClipAtPoint(SuccessSound,Camera.main.transform.position,volume);
        }
        else if (!res)
        {
            // Send it to the bad ending
            ConclusionCanvas.gameObject.SetActive(false);
            EndingCanvas.gameObject.SetActive(true);
            AudioSource.PlayClipAtPoint(FailureSound,Camera.main.transform.position,volume);
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
