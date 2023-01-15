using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float collisionOffset = 0.05f;
    public ContactFilter2D moveFilter;

    Vector2 moveInput;
    Rigidbody2D rb;

    Animator animator;
    // Start is called before the first frame update
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate(){
        if(moveInput != Vector2.zero){
            bool success = TryMove(moveInput);

            if(!success){
                success = TryMove(new Vector2(moveInput.x, 0));
                if(!success){
                    success = TryMove(new Vector2(0, moveInput.y));
                }
            }

            animator.SetBool("isMoving", true);
            if(moveInput.x < 0){
                animator.SetBool("movingLeft", true);
                animator.SetBool("movingRight", false);
            }
            else if(moveInput.x > 0){
                animator.SetBool("movingRight", true);
                animator.SetBool("movingLeft", false);
            }
            else if(moveInput.x == 0){
                animator.SetBool("movingRight", false);
                animator.SetBool("movingLeft", false);
            }
            if(moveInput.y > 0){
                animator.SetBool("movingUp", true);
                animator.SetBool("movingDown", false);
            }
            else if(moveInput.y < 0){
                animator.SetBool("movingDown", true);
                animator.SetBool("movingUp", false);
            }
            else if(moveInput.y == 0){
                animator.SetBool("movingUp", false);
                animator.SetBool("movingDown", false);
            }
            return;
            
        }
        animator.SetBool("isMoving", false);

    }

    private bool TryMove(Vector2 inputVec){
        int count = rb.Cast(
            inputVec,
            moveFilter,
            castCollisions,
            moveSpeed * Time.fixedDeltaTime + collisionOffset
        );

        if(count == 0){
            rb.MovePosition(rb.position + inputVec * moveSpeed * Time.fixedDeltaTime);
            return true;
        }
        else{
            return false;
        }
    }

    void OnMove(InputValue moveValue){
        moveInput = moveValue.Get<Vector2>();
    }
}
