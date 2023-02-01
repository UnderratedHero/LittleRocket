using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float mainThrust = 1000f;
    [SerializeField] float rotationThrust = 100f;
    Rigidbody rb;
    void Start()
    {
       rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        ForwardMooving();
        Rotation();
    }
    void ForwardMooving()
    {
        bool forward = Input.GetKey(KeyCode.W);
        if(forward)
        {
           rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);//даем нашему твердому телу силу 
        }
    }
    void Rotation()
    {
        bool right = Input.GetKey(KeyCode.D);
        bool left = Input.GetKey(KeyCode.A);
        if(right)
        {
            RotationFunc(-rotationThrust);
        }
        else if(left)
        {
            RotationFunc(rotationThrust);
        }
    }
    void RotationFunc(float rotationSign)
    {
        rb.freezeRotation = true;//заморозил вращение для того, чтобы не было бага с конфликтом вращения в разные стороны
        transform.Rotate(Vector3.forward * Time.deltaTime * rotationSign);
        rb.freezeRotation = false;
    }
}
