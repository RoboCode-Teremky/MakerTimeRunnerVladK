using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    private Rigidbody _rb;
    public float speed;
    void Awake(){
        _rb = GetComponent<Rigidbody>();
    }
    void Start(){
        _rb.velocity = transform.forward * speed;
        Destroy(gameObject, 10.0f);
    }
    void OnCollisionEnter(Collision other)
    {
        Destroy(gameObject);
    }
}
