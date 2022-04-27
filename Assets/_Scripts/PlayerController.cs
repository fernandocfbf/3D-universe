using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour{
    float _baseSpeed = 10.0f;
    float _gravidade = 9.8f;
    CharacterController characterController;
    void Start(){
        characterController = GetComponent<CharacterController>();
    }

    void Update(){
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        float mouse_dX = Input.GetAxis("Mouse X");
        float mouse_dY = Input.GetAxis("Mouse Y");

        float y = 0;
        if(!characterController.isGrounded) y = -_gravidade;

        Vector3 direction = new Vector3(x, y, z);
        characterController.Move(direction * _baseSpeed * Time.deltaTime);
        transform.Rotate(Vector3.up, mouse_dX);
    }
}
