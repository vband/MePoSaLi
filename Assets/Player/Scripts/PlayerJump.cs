using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    // Parâmetros ajustáveis
    [SerializeField]
    private float jumpVelocity = 5f;
    [SerializeField]
    private float fallMultiplier = 2.5f;

    // Componentes
    private Rigidbody2D rb;
    private PlayerInputHandler input;
    private PlayerCollisionController collisionController;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        input = GetComponent<PlayerInputHandler>();
        collisionController = GetComponent<PlayerCollisionController>();
    }

    private void FixedUpdate ()
    {
        if (collisionController.IsGrounded && input.JumpTap)
        {
            Jump();
        }

        if (IsFalling())
        {
            ApplyFallMultiplier();
        }
        else if (IsMovingUpwards() && !input.JumpHold)
        {
            ApplyFallMultiplier();
        }
	}

    private void Jump()
    {
        rb.velocity = Vector2.up * jumpVelocity;
    }

    private void ApplyFallMultiplier()
    {
        rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.fixedDeltaTime;
    }

    private bool IsFalling()
    {
        return rb.velocity.y < 0;
    }

    private bool IsMovingUpwards()
    {
        return rb.velocity.y > 0;
    }
}
