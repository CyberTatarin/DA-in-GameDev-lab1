using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinObject : MonoBehaviour
{
    public float Speed;
    public float AngularSpeed;
    protected Rigidbody r;
    // Start is called before the first frame update
    void Start()
    {
        r = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Speed = r.velocity.magnitude;
        AngularSpeed = r.angularVelocity.magnitude;

        r.AddTorque(Vector3.forward);
    }
}
