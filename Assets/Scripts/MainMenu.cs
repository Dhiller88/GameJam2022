using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject mainCanvas;
    [SerializeField] GameObject creditCanvas;
    [SerializeField] GameObject instructionsScreen;
    private bool switched = false;
    // Start is called before the first frame update
    void Start()
    {
        mainCanvas.SetActive(true);
        creditCanvas.SetActive(false);
        instructionsScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator PlaySound()
    {
        AudioSource source = GetComponent<AudioSource>();
        //source.clip = Soundbyte;
        source.Play();
        yield return new WaitWhile (()=> source.isPlaying);  
        SceneManager.LoadScene(1);
    }

    public void LoadMainGame()
    {
        mainCanvas.SetActive(false);
        instructionsScreen.SetActive(true);
        StartCoroutine(PlaySound());
    }

    public void ChangeCanvas()
    {
        if (switched)
        {
            mainCanvas.SetActive(true);
            creditCanvas.SetActive(false);
        }
        else
        {
            mainCanvas.SetActive(false);
            creditCanvas.SetActive(true);
        }
        switched = !switched;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
