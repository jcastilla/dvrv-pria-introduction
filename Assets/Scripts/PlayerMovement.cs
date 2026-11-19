using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float force = 10f;
    private Rigidbody rb;

    //Bonus Extra
    public float jumpForce = 5f;
    public bool isGrounded;

    private Vector2 input;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void OnMove(InputValue value)
    {
        input = value.Get<Vector2>();
        Debug.Log(input);
    }
    public void OnJump(InputValue value)
    {
        if (!isGrounded) return;

        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isGrounded = false;
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(input.x,0,input.y);
        rb.AddForce(movement*force,ForceMode.Force);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isGrounded = true;
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isGrounded = false;
    }
}