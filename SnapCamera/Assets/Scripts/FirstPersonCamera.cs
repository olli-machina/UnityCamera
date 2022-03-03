using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    public float moveSpeed, lookSpeed;

   // public GameObject playerBody;

    float xRotation = 0f, yRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * lookSpeed * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * lookSpeed * Time.deltaTime;

        xRotation -= mouseY;
        yRotation += mouseX;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
      //  playerBody.transform.rotation = transform.localRotation;
    }
}
