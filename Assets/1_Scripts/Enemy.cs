using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lagooneng.DodgeGame
{
    public enum EnemyType
    {
        DOWN,
        UP,
        RIGHT,
        LEFT
    }

    public class Enemy : MonoBehaviour
    {
        private Rigidbody2D rb;
        [SerializeField] float speed = 2.0f;
        [SerializeField] EnemyType type = EnemyType.DOWN;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            switch( type )
            {
                case EnemyType.DOWN:
                    rb.velocity = new Vector2(0.0f, -speed);
                    break;
                case EnemyType.LEFT:
                    rb.velocity = new Vector2(-speed, 0.0f);
                    break;
                case EnemyType.RIGHT:
                    rb.velocity = new Vector2(speed, 0.0f);
                    break;
                case EnemyType.UP:
                    rb.velocity = new Vector2(0.0f, speed);
                    break;
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if( collision.CompareTag("Destroy") )
            {
                Destroy(this.gameObject);
            }
        }
    }
}