using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Rigidbody rb;

    private Vector3 moveDirection;

    private PlayerAnimation PlayerAnimation;

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

        PlayerAnimation.UpdateMovement(moveInput);

        moveDirection = new Vector3(horizontal, 0, vertical).normalized;
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveDirection * moveSpeed * Time.fixedDeltaTime);
    }
}