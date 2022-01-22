using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerInputHadnler : MonoBehaviour
{
    public float mouSensitivity = 1f;
    public float TriggerAxisThreshold = 0.4f;
    public bool InvertYAxis = false;
    public bool InvertXAxis = false;

    PlayerCharacterController m_PlayerCharacterController;

    public Transform playerBody;

    float xRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        m_PlayerCharacterController = GetComponent<PlayerCharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);



    }


    public void ReloadAmmo()
    {
        if (Input.GetKeyDown("r"))
        {
            print("ReloadAmmo");
        }
    }

}