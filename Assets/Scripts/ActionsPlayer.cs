using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionsPlayer : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Animator _animator;
    private const float Velocity = 4f;
    private bool _changeOrientation = true;
    public int coins = 0;

    public Slider slider;
    public Text contadorCoins;

    public Transform tp;
    public Vector2 posicionReinicio;

    void Start()
    {
        slider.value = 100;
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
        posicionReinicio = transform.position;
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

        if (Input.GetKey(KeyCode.LeftControl))
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
        _rb.AddForce(Vector2.up * 5, ForceMode2D.Impulse);
    }

    private void Win()
    {
        _animator.SetTrigger("winTrigger");
    }

    private void Die()
    {
        _animator.SetTrigger("dieTrigger");
        slider.value = 0;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            coins += 3;
            contadorCoins.text = "" + coins;
        }
    }

    private void Restart()
    {
        transform.position = posicionReinicio;
        slider.value = 100;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("floor"))
        {
            Die();
            Invoke(nameof(Restart), 2f);
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            slider.value -= 10;
            if (slider.value <= 0)
            {
                Die();
                Invoke(nameof(Restart), 2f);
            }
        }
    }
}