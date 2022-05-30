using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickMeAreas : MonoBehaviour
{
    private bool inspected = false;
    [SerializeField] public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;
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

    void OnMouseEnter()
    {
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
    }

    void OnMouseExit()
    {
        Cursor.SetCursor(null, Vector2.zero, cursorMode);
    }


    private void OnMouseDown() {
        if (!gameplayScriptObject.GetSoundPlaying())
        {
            if (gameplayScriptObject.GetZoomStatus())
            {
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
                CameraMovement theCamera = FindObjectOfType<CameraMovement>();
                theCamera.CameraMoveToLocation(xPos, yPos);
                gameplayScriptObject.SwitchZoom();
            }
        }
    }

    IEnumerator PlaySound()
    {
        AudioSource source = GetComponent<AudioSource>();
        //source.clip = Soundbyte;
        source.Play();
        yield return new WaitWhile (()=> source.isPlaying);  
        gameplayScriptObject.ChangeSoundPlayingStatus();  
    }
}
