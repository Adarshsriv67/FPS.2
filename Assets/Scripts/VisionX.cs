using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionX : MonoBehaviour
{
    [SerializeField]
    private float senstivity=1f;
    void Start()
    {
        
    }
    void Update()
    {
        float mouseX=Input.GetAxis("Mouse X");
        transform.localEulerAngles=new Vector3(transform.localEulerAngles.x,transform.localEulerAngles.y+(mouseX*senstivity),transform.localEulerAngles.z);

    }
}
