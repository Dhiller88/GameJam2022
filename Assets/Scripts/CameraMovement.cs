using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    int currentxPosition = 0;
    int currentyPosition = 0;
    [SerializeField] GameObject roomPanel;
    [SerializeField] GameObject returnButton;

    int totalImages;
    Vector3 rememberMe;
    // Start is called before the first frame update
    void Start()
    {
        roomPanel.SetActive(true);
        returnButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CameraMove(int direction)
    {
        // To Do: Make a call to the gameScreen to know how many images are in the current area
        currentxPosition = (currentxPosition + (direction * 30)) % (totalImages * 30);
        if (currentxPosition < 0) 
        {
            currentxPosition = (totalImages - 1) * 30;
        }
        transform.position = new Vector3(currentxPosition, currentyPosition,-10);
    }

    public void CameraMoveRoom(int NumberOfRoomsThenRoomYValue)
    {
        currentyPosition = NumberOfRoomsThenRoomYValue%10;
        totalImages = (NumberOfRoomsThenRoomYValue - currentyPosition) / 10;
        transform.position = new Vector3(0, currentyPosition, -10);
    }

    public void CameraMoveToLocation(int x, int y)
    {
        rememberMe = transform.position;
        transform.position = new Vector3(x,y,-10);
        returnButton.SetActive(true);
        roomPanel.SetActive(false);
    }

    public void ReturnCameraPosition()
    {
        transform.position = rememberMe;
        returnButton.SetActive(false);
        roomPanel.SetActive(true);
    }
}
