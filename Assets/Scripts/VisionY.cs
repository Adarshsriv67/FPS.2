using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionY : MonoBehaviour
{
    [SerializeField]
    private float senstivity=5f;
    void Start()
    {
        
    }
    void Update()
    {
        float mouseY=-(Input.GetAxis("Mouse Y"));
        transform.localEulerAngles=new Vector3(transform.localEulerAngles.x+(mouseY*senstivity),transform.localEulerAngles.y,transform.localEulerAngles.z);
    }
}
