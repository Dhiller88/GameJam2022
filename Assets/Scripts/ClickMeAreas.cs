using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickMeAreas : MonoBehaviour
{
    private bool inspected = false;
    [SerializeField] string MotiveStatement = "";
    [SerializeField] string WeaponStatement = "";
    [SerializeField] string ScriptLines = "";
    //[SerializeField] AudioClip Soundbyte;
    [SerializeField] GamePlay gameplayScriptObject;
    [SerializeField] int xPos;
    [SerializeField] int yPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown() {
        if (!gameplayScriptObject.GetSoundPlaying())
        {
            if (gameplayScriptObject.GetZoomStatus())
            {
                Debug.Log("Oops");
                gameplayScriptObject.ChangeSoundPlayingStatus();
                if (!inspected)
                {
                    gameplayScriptObject.AddMotive(MotiveStatement);
                    gameplayScriptObject.AddWeapon(WeaponStatement);
                }
                StartCoroutine(PlaySound());
                inspected = true;
            }
            else
            {
                Debug.Log("In theory, this worked.");
                CameraMovement theCamera = FindObjectOfType<CameraMovement>();
                theCamera.CameraMoveToLocation(xPos, yPos);
                gameplayScriptObject.SwitchZoom();
            }
        }
    }

    IEnumerator PlaySound()
    {
        Debug.Log("Got to the CoRoutine");
        AudioSource source = GetComponent<AudioSource>();
        //source.clip = Soundbyte;
        source.Play();
        yield return new WaitWhile (()=> source.isPlaying);  
        gameplayScriptObject.ChangeSoundPlayingStatus();  
    }
}
