using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Vector3 mousePosition;
    public Rigidbody2D rigidbody2D;

    public float speed = 1f;
    public float minY = 0f;
    public float maxY = 0f;

    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rigidbody2D.MovePosition(new Vector2(rigidbody2D.position.x, mousePosition.y));
    }

    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

    }
}
