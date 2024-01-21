using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform GFX;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform feetPos;
    [SerializeField] private float groundDistance = 0.25f;
    [SerializeField] private float jumpTime = 0.3f;
    [SerializeField] private float jumpCooldown = 0.5f;
    private bool canJump = true;

    private bool isGrounded = false;
    private bool isJumping = false;
    private float jumpTimer;

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, groundDistance, groundLayer);

        if (isGrounded)
        {
            if (canJump && Input.GetButtonDown("Jump"))
            {
                isJumping = true;
                jumpTimer = 0;  
                rb.velocity = Vector2.up * jumpForce;
                canJump = false;  
            }

            if (isJumping && Input.GetButton("Jump"))
            {
                if (jumpTimer < jumpTime)
                {
                    rb.velocity = Vector2.up * jumpForce;
                    jumpTimer += Time.deltaTime;
                }
                else
                {
                    isJumping = false;
                }
            }

            if (Input.GetButtonUp("Jump"))
            {
                isJumping = false;
            }
        }
             if (!canJump)
        {
            jumpCooldown -= Time.deltaTime;
            if (jumpCooldown <= 0)
            {
                canJump = true;
                jumpCooldown = 0.5f;  // Réinitialiser le cooldown
            }
        }
    }
}
    


