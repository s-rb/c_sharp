using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeRotationPlayerController : MonoBehaviour
{
    
    public Rigidbody rb;

    public float force;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.AddTorque(Vector3.forward * force * Time.fixedDeltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.AddTorque(Vector3.back * force * Time.fixedDeltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddTorque(Vector3.left * force * Time.fixedDeltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddTorque(Vector3.right * force * Time.fixedDeltaTime);
        }
        if (Input.GetKey(KeyCode.Plus))
        {
            rb.AddTorque(Vector3.up * force * Time.fixedDeltaTime);
        }
        if (Input.GetKey(KeyCode.Minus))
        {
            rb.AddTorque(Vector3.down * force * Time.fixedDeltaTime);
        }
    }
}
