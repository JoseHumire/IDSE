using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionsPlayer : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Animator _animator;
    private const float Velocity = 2f;
    private bool _changeOrientation = true;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
       // _rb.velocity = new Vector2(horizontal * Velocity, _rb.velocity.y);

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            Walk();
            ChangeOrientation(horizontal);
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            Walk();
            ChangeOrientation(horizontal);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        
        if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
        {
            Attack();
        }

        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            Defense();
        }

        if (!Input.anyKey)
        {
            Idle();
        }
    }

    private void ChangeOrientation(float horizontal)
    {
        if (horizontal > 0 && !_changeOrientation || horizontal < 0 && _changeOrientation)
        {
            _changeOrientation = !_changeOrientation;
            var scale = transform.localScale;
            scale.x *= -1;

            transform.localScale = scale;
        }
    }

    private void Walk()
    {
        _animator.SetTrigger("walkTrigger");
        var horizontal = Input.GetAxis("Horizontal");
        _rb.velocity = new Vector2(horizontal * Velocity, _rb.velocity.y);
    }

    private void Attack()
    {
        _animator.SetTrigger("attackTrigger");
        //Idle();
    }

    private void Defense()
    {
        _animator.SetTrigger("defenseTrigger");
    }
    
    private void Idle()
    {
        _animator.SetTrigger("idleTrigger");
    }

    private void Jump()
    {
        _animator.SetTrigger("jumpTrigger");
        _rb.AddForce(Vector2.up * 8, ForceMode2D.Impulse);
    }

    private void Win()
    {
        _animator.SetTrigger("winTrigger");
    }
    
    private void Die()
    {
        _animator.SetTrigger("dieTrigger");
    }


}