using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickMeAreas : MonoBehaviour
{
    private bool inspected = false;
    [SerializeField] string MotiveStatement;
    [SerializeField] string WeaponStatement;
    [SerializeField] string ScriptLines;
    [SerializeField] AudioClip Soundbyte;
    [SerializeField] GamePlay gameplayScriptObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown() {
        if (gameplayScriptObject.GetSoundPlaying())
        {
            gameplayScriptObject.ChangeSoundPlayingStatus();
            gameplayScriptObject.AddMotive(MotiveStatement);
            gameplayScriptObject.AddWeapon(WeaponStatement);
            StartCoroutine(PlaySound());
        }

    }

    IEnumerator PlaySound()
    {
        AudioSource source = GetComponent<AudioSource>();
        source.Play();
        yield return new WaitWhile (()=> source.isPlaying);  
        gameplayScriptObject.ChangeSoundPlayingStatus();  
    }
}
