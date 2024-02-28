using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private CharacterController _controller;
    [SerializeField]
    public float speed=3.5f;
    private float gravity=9.81f;
    void Start()
    {
        _controller=GetComponent<CharacterController>();
        //Cursor.visible=false;
        //Cursor.lockState=CursorLockMode.Locked;
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            //Cursor.visible=true;
            //Cursor.lockState=CursorLockMode.None;
        }
        Vector3 direction=new Vector3(Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical"));
        Vector3 velocity=direction*speed;
        velocity.y-=gravity;
        velocity=transform.transform.TransformDirection(velocity);
        _controller.Move(velocity*Time.deltaTime);        
    }
}
