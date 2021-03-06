using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;

    public float force;

    public float jumpForce;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    // void Update() - Обновление каждый кадр
    void FixedUpdate() // обновление в фиксированное количество кадров
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(Vector3.forward * force * Time.fixedDeltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(Vector3.back * force * Time.fixedDeltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(Vector3.left * force * Time.fixedDeltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(Vector3.right * force * Time.fixedDeltaTime);
        }
        
        if (Input.GetKeyDown(KeyCode.Space)) // GetKey - всегда нажата клавиша, GetKeyDown - возвращается один раз
        {
            rb.AddForce(Vector3.up * jumpForce * Time.fixedDeltaTime);
        }
    }
}