using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float collisionOffset = 0.05f;
    public ContactFilter2D moveFilter;

    Vector2 moveInput;
    Rigidbody2D rb;
    // Start is called before the first frame update
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
            
        }
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
