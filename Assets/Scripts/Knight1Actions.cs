using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight1Actions : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;
    SpriteRenderer sp;
    public float speed = 1f;
    public float walkLimit = 3f;
    public Animator animator;

    private Vector2 startingPos;
    public bool walkingBack = false;
    public bool attacking;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
        startingPos = transform.position;
        attacking = false;
    }

    private void FixedUpdate() {

        if(transform.position.x >= (startingPos.x + walkLimit) && !walkingBack && !attacking){
            animator.SetBool("attack", true);        
            this.attacking = true;
            Debug.Log("1");
        }else if(transform.position.x < startingPos.x && walkingBack && !attacking){
            animator.SetBool("attack", true);        
            this.attacking = true;
            Debug.Log("2");
        }else{
            Debug.Log("3");
            Vector2 v = new Vector2(speed, 0);
            rb.velocity = v;
        }
    }

    private void TurnAround(){
        this.speed = -speed;
        sp.flipX = !sp.flipX;
    }

    private void StopAttacking(){
        this.attacking = false;
        animator.SetBool("attack", false);
        this.walkingBack = !this.walkingBack;
    }
}
