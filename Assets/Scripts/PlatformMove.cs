using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    [SerializeField] 
    private float speed = 1.0f;
    private float maxSpeed = 10.0f;
    private float acceleration = 0.1f;
    
    void Update()
    {
        if (speed < maxSpeed)
        {
            speed += acceleration * Time.deltaTime;
            speed = Mathf.Min(speed, maxSpeed);
        }
        transform.Translate(Vector3.back*speed*Time.deltaTime);
    }
}
