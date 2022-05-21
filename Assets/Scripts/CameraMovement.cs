using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] int currentPosition = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CameraMove(int direction)
    {
        // To Do: Make a call to the gameScreen to know how many images are in the current area
        int lengthOfImages = 4;
        currentPosition = (currentPosition + (direction * 30)) % (lengthOfImages * 30);
        if (currentPosition < 0) 
        {
            currentPosition = (lengthOfImages - 1) * 30;
        }
        Debug.Log(currentPosition);
        transform.position = new Vector3(currentPosition,0,-10);
    }
}
