using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraController : MonoBehaviour
{
    [Header("Controls")]
  public Joystick joystick;
  public float controlSensitivity = 2.0f;

    //Reference to the player body to rotate it as we move the camera.
    public Transform playerBody;

    //Move up and down.
    float xRotation = 0f;
    public GameController control;

    // Start is called before the first frame update
    void Start()
    {
        //Cursor.lockState = CursorLockMode.Confined;
    }

    // Update is called once per frame
    void Update()
    {
        //If you're in the pause menu or if the player is dead or if they're in some UI or if level complete, don't do any of the code below.
        if (PauseMenu.GameIsPaused || control.levelComplete || control.isDead || EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

    //Reference to the mouse motions.
    //float mouseX = Input.GetAxis("Mouse X") * controlSensitivity * Time.deltaTime;
    //float mouseY = Input.GetAxis("Mouse Y") * controlSensitivity * Time.deltaTime;

    float mouseX = joystick.Horizontal * controlSensitivity;
    float mouseY = joystick.Vertical * controlSensitivity;

        //Rotate the camera up and down.
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 65f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        //Rotate the body of the player side to side.
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
