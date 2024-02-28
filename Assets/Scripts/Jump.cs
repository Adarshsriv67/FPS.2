using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Jump : MonoBehaviour
{
    public float speed;
    public float gravity=-20f;
    public float jumpSpeed=15;
    CharacterController characterController;
    Vector3 moveVelocity;
    void Awake()
    {
       characterController=GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {      
       if(characterController.isGrounded && Input.GetButtonDown("Jump"))
       {
           moveVelocity.y=jumpSpeed*1.5f;
       } 
       moveVelocity.y +=gravity*Time.deltaTime;
       characterController.Move(moveVelocity*Time.deltaTime);
    }
}
