using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour{
    float _baseSpeed = 10.0f;
    float _gravidade = 9.8f;
    CharacterController characterController;
    GameObject playerCamera;
    float cameraRotation;


    void Start(){
        playerCamera = GameObject.Find("Main Camera");
        cameraRotation = 0.0f;
        characterController = GetComponent<CharacterController>();
    }

    void Update(){
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        float mouse_dX = Input.GetAxis("Mouse X");
        float mouse_dY = Input.GetAxis("Mouse Y");

        cameraRotation += mouse_dY;
        cameraRotation = Mathf.Clamp(cameraRotation, -75.0f, 75.0f);

        float y = 0;
        if(!characterController.isGrounded) y = -_gravidade;

        Vector3 direction = transform.right * x + transform.up * y + transform.forward * z;
        characterController.Move(direction * _baseSpeed * Time.deltaTime);
        transform.Rotate(Vector3.up, mouse_dX);
        playerCamera.transform.localRotation = Quaternion.Euler(cameraRotation, 0.0f, 0.0f);
    }
}
