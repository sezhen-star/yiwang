using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Rigidbody rb;

    private Vector3 moveDirection;

    private PlayerAnimation PlayerAnimation;

    // Shitft Check
    [SerializeField] private float walkSpeed = 5f;

    [SerializeField] private float runSpeed = 8f;

    private bool isRunning;

    // move Speed
    float currentSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        PlayerAnimation = GetComponent<PlayerAnimation>();
    }

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector2 moveInput = new Vector2(horizontal, vertical).normalized;

        //shift check
        isRunning = Input.GetKey(KeyCode.LeftShift);

        currentSpeed = isRunning ? runSpeed : moveSpeed;

        PlayerAnimation.UpdateMovement(moveInput, isRunning);

        moveDirection = new Vector3(horizontal, 0, vertical).normalized;
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveDirection * currentSpeed * Time.fixedDeltaTime);
    }
}