using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class CameraMovement : MonoBehaviour
{
    public GameObject jugador;
    public Vector2 min;
    public Vector2 max;
    public float suavizado;
    private Vector2 velocity;

    void FixedUpdate()
    {
        float posX = Mathf.SmoothDamp(
            transform.position.x,
            jugador.transform.position.x,
            ref velocity.x,
            suavizado
        );

        float posY = Mathf.SmoothDamp(
            transform.position.y,
            jugador.transform.position.y,
            ref velocity.y,
            suavizado
        );

        transform.position = new Vector3(
            Mathf.Clamp(posX, min.x, max.x),
            Mathf.Clamp(posY, min.y, max.y),
            transform.position.z
        );
    }
}