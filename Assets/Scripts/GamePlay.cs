using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// The purpose of this script is to be able to move all things along and keep track of game vars
// Vars: List of weapons, List of motives, soundfile playing
// This script will need a singleton pattern since it will be used across things.
public class GamePlay : MonoBehaviour
{
    private List<string> Weapons;
    private List<string> Motives;
    private bool SoundPlaying = false;
    private bool ZoomedIn = false;
    [SerializeField] GameObject RoomLocations;
    [SerializeField] GameObject GoBackButton;
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<Timer>().BeginTime();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EndInspection()
    {
        // This will take us to the conclusion screen
    }

    public void Ending(bool success)
    {
        if (success)
        {
            // Take us to the success ending
        }
        else
        {
            // Take us to the fail ending
        }
    }

    public void AddMotive(string Motive)
    {
        Motives.Add(Motive);
    }

    public void AddWeapon(string Weapon)
    {
        Weapons.Add(Weapon);
    }

    public bool GetSoundPlaying()
    {
        return SoundPlaying;
    }

    public void ChangeSoundPlayingStatus()
    {
        SoundPlaying = (!SoundPlaying);
    }

    public void SwitchZoom()
    {
        ZoomedIn = (!ZoomedIn);
    }

    public bool GetZoomStatus()
    {
        return ZoomedIn;
    }
}
