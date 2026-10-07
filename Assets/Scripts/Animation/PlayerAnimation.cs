using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;

    private static readonly int MoveSpeedHash = Animator.StringToHash("MoveSpeed");

    private static readonly int MoveXHash = Animator.StringToHash("MoveX");

    private static readonly int MoveYHash = Animator.StringToHash("MoveY");

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void UpdateMovement(Vector2 moveInput)
    {
        animator.SetFloat(MoveSpeedHash, moveInput.magnitude);
        animator.SetFloat(MoveXHash, moveInput.x);
        animator.SetFloat(MoveYHash, moveInput.y);
    }
}