using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight3Actions : MonoBehaviour
{    
    Rigidbody2D rb;
    SpriteRenderer sp;
    public float speed = 1f;
    public Animator animator;
    public bool attacking;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void FixedUpdate() {
        
    }
}
