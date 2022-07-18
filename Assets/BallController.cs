using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{

    public float maxSpeed;

    public Vector2 velocity;

    public Rigidbody2D rigidbody2D;
    public GameController gameController;

    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            velocity.x = Mathf.Clamp(-velocity.x * 1.1f, -maxSpeed, maxSpeed);
            velocity.y = (rigidbody2D.position.y - collision.collider.attachedRigidbody.position.y) * 5;
            gameController.playListSound(1);
        } 
        
        if (collision.gameObject.layer == 7) 
        {
            velocity.y = -velocity.y;
            gameController.playListSound(1);
        }

        if (collision.gameObject.layer == 8)
        {
            Score("Enemy");
        }

        if (collision.gameObject.layer == 9)
        {
            Score("Player");
        }
    }

    public void Score(string whoScored)
    {
        gameObject.transform.position = Vector2.zero;
        velocity.y = 0;
        velocity.x = whoScored == "Enemy" ? 5 : -5;
        gameController.playListSound(2);

        if (whoScored == "Player")
        {
            gameController.playerScore++;
        }
        else
        {
            gameController.enemyScore++;
        }
    }

    private void FixedUpdate()
    {
        rigidbody2D.MovePosition(rigidbody2D.position + velocity * Time.deltaTime);
    }

}
