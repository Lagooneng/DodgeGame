using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lagooneng.DodgeGame
{
    public class Player : MonoBehaviour
    {
        private bool isActivated = true;

        public static Player Instance;

        private Rigidbody2D rb;
        private Animator animator;
        [SerializeField] float speed = 5.0f;
        [SerializeField] float jumpPower = 10.0f;
        [SerializeField] Transform groundDetection;
        [SerializeField] CircleCollider2D body;
        [SerializeField] CircleCollider2D trigger;

        private bool grounded = true;
        private bool doubleJumped = false;

        private void Awake()
        {
            Instance = this;
            rb = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();
        }


        void Update()
        {
            if (!isActivated) return;

            if( Input.GetKey( KeyCode.DownArrow ) )
            {
                transform.localScale = new Vector3(transform.localScale.x, 0.5f, transform.localScale.z);
                body.radius = 0.2f;
                trigger.radius = 0.2f;
            }
            else
            {
                transform.localScale = new Vector3(transform.localScale.x, 1.0f, transform.localScale.z);
                body.radius = 0.38f;
                trigger.radius = 0.3f;
            }

            if ( Input.GetKeyDown(KeyCode.Space) && CountDown.Instance.CountDownUsed )
            {
                if (grounded)
                {
                    ActionJump();
                    grounded = false;
                }
                else
                {
                    if (!doubleJumped)
                    {
                        doubleJumped = true;
                        ActionJump();
                    }
                }
            }

            Collider2D[] cols = Physics2D.OverlapPointAll(groundDetection.position);

            bool successDetection = false;
            foreach (Collider2D col in cols)
            {
                if (col.CompareTag("Ground"))
                {
                    grounded = true;
                    doubleJumped = false;
                    successDetection = true;
                    break;
                }
            }

            if (!successDetection) grounded = false;

            if ( Input.GetKey(KeyCode.RightArrow) )
            {
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x),
                                                    transform.localScale.y, transform.localScale.z);

                rb.velocity = new Vector2(speed, rb.velocity.y);

                animator.SetTrigger("Run");
            }
            else if( Input.GetKey(KeyCode.LeftArrow) )
            {
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x) * -1.0f,
                                                    transform.localScale.y, transform.localScale.z);

                rb.velocity = new Vector2(speed * -1.0f, rb.velocity.y);
                animator.SetTrigger("Run");
            }
            else
            {
                rb.velocity = new Vector2( 0.0f, rb.velocity.y );
                animator.SetTrigger("Idle");
            }  
        }

        private void ActionJump()
        {
            rb.AddForce(new Vector2(0.0f, jumpPower));
        }

        public void GameEnd()
        {
            isActivated = false;
            Time.timeScale = 0.0f;

            GameManager.Instance.GameEnd();
        }
    }
}


