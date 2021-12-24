using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight3Actions : MonoBehaviour
{    
    Rigidbody2D rb;
    SpriteRenderer sp;
    public float xSpeed = 1f;
    public float ySpeed = 1f;
    public Animator animator;
    public bool attacking;
    public GameObject projectile;
    public bool faceOtherWay = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
        if (faceOtherWay)
        {
            this.xSpeed = -xSpeed;
            sp.flipX = true;
        }

    }

    // Update is called once per frame
    private void FixedUpdate() {
        
    }

    private void Attack(){
        animator.SetTrigger("attack");
        animator.SetBool("isIdle", false);
    }

    private void Shoot()
    {
        GameObject newProjectile = Instantiate(projectile, transform.position, transform.rotation);
        newProjectile.SetActive(true);
        var projectileDirection = transform.right * xSpeed;
        projectileDirection.y = ySpeed;
        newProjectile.GetComponent<Rigidbody2D>().AddForce(projectileDirection, ForceMode2D.Impulse);

        Destroy(newProjectile, 3);
    }
    private void GoIdle(){
        animator.SetBool("isIdle", true);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("KnightProjectile"))
        {
            Physics2D.IgnoreCollision(col.collider, GetComponent<BoxCollider2D>());
        }
    }
}
