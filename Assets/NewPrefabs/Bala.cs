using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Bala : MonoBehaviour
{
    private Animator _animator;
    [SerializeField] private float velocidad;
    [SerializeField] private float daño;
    private bool isActive = true;
    private bool isRight = true;

    void Start()
    {
        _animator = GetComponent<Animator>();
        Destroy(gameObject, 2.5f);
    }

    void Update()
    {
        if (isActive)
        {
            if (isRight)
            {
                dispararDerecha();
            }
            else
            {
               dispararIzquierda();
            }
        }
    }

    void dispararDerecha()
    {
        transform.Translate(Vector2.right * velocidad * Time.deltaTime);
    }

    void dispararIzquierda()
    {
        transform.Translate(Vector2.left * velocidad * Time.deltaTime);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Jugador"))
        {
            return;
        }
        else
        {
            _animator.SetTrigger("colisionTrigger");
            isActive = false;
            Destroy(gameObject, 0.5f);
        }
    }
}