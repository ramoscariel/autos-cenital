using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float steerSpeed;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float vInput = Input.GetAxis("Vertical");
        rb.velocity = transform.forward*vInput*speed;
        float horizontalInput = Input.GetAxis("Horizontal");
        rb.AddTorque(Vector3.up * steerSpeed * horizontalInput);
    }
}
