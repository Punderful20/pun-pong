using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public Rigidbody2D ball;
    public Rigidbody2D rigidbody2D;

    public float speed = 5f;
    public float yOffset = 0f;
    public float yOffsetSpeed = 0.01f;
    public float maxYOffset = 1f;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rigidbody2D.MovePosition(Vector2.MoveTowards(rigidbody2D.position, ball.position + new Vector2(0, yOffset), Time.deltaTime * speed));
    }

    // Update is called once per frame
    void Update()
    {
        yOffset += Random.Range(-yOffsetSpeed, yOffsetSpeed);
        yOffset = Mathf.Clamp(yOffset, -maxYOffset, maxYOffset);
    }
}
