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
            int count = rb.Cast(
                moveInput,
                moveFilter,
                castCollisions,
                moveSpeed * Time.fixedDeltaTime + collisionOffset
            );

            if(count == 0){
                rb.MovePosition(rb.position + moveInput * moveSpeed * Time.fixedDeltaTime);
            }
            
        }
    }

    void OnMove(InputValue moveValue){
        moveInput = moveValue.Get<Vector2>();
    }
}
