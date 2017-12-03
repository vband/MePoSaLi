using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableMovement : MonoBehaviour
{
    // Parâmetros ajustáveis
    [SerializeField]
    private float amplitude = 3f;
    [SerializeField]
    private float angularSpeed = 1f;
    [SerializeField]
    private float horizontalSpeed = 2f;

    // Componentes
    private Rigidbody2D rb;

    private float startYPos, startTime;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        MoveHorizontally();
        startYPos = transform.position.y;
        startTime = Time.time;
    }

    private void FixedUpdate()
    {
        MoveVertically();
    }

    private void MoveHorizontally()
    {
        rb.velocity = new Vector2(-horizontalSpeed, 0f);
    }

    private void MoveVertically()
    {
        transform.position = new Vector3 (
            transform.position.x,
            startYPos + Mathf.Sin(Mathf.Deg2Rad * (Time.time + startTime) * angularSpeed) * amplitude,
            transform.position.z);
    }
}
