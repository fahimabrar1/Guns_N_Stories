using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    /*
        ............................................................................................
        ............................................................................................

            This CameraController is responsible for the player camera view.

        ............................................................................................
        ............................................................................................
        */
    public float mouseSsensitivity = 100f;
    public Transform player;

    float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSsensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSsensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation,-90,90);

        transform.localRotation = Quaternion.Euler(xRotation,0f,0f);
        player.Rotate(Vector3.up * mouseX);

    }
}
