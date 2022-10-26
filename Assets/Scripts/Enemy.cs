using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //BALAZO
    public GameObject bullet;

    //MOVIMIENTO
    public float speed = 1f;
    public float changeTime = 1f;
    float timer;
    int direction;

    //Rigidbody2D rb2d;


    //ATTACK
    public float attackInterval = 5f;
    //bool isAttacking;
    float timeToAttack;
    bool isAttacking;


    //ANIMACIÓN
    Animator animator;

    void Start()
    {
        direction = 1;
        timer = changeTime;
        animator = GetComponent<Animator>();
        animator.SetFloat("X_direction", direction);

       
        animator.SetBool("Attack", false);
        timeToAttack = attackInterval;

        isAttacking = false;

        //rb2d = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        movement();
        //Vector2 velocity = rb2d.velocity;

        timeToAttack -= Time.deltaTime;
        if (timeToAttack <= 0 && !isAttacking)
        {
            animator.SetBool("Attack", true);

            isAttacking = true;

            Vector2 robotPos = transform.position;
            Instantiate(bullet, new Vector2(robotPos.x - 1, robotPos.y), Quaternion.identity);
        }

        if (timeToAttack <= -1f)
        {
            animator.SetBool("Attack", false);
            timeToAttack = attackInterval;
            isAttacking = false;
        }

    }

    /*void FixedUpdate()
    {
        Vector2 velocity = rb2d.velocity;
        velocity.x = 10f * horizontal;
        rb2d.velocity = velocity;
    }*/


    void movement()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            direction = direction * -1;
            timer = changeTime;
            animator.SetFloat("X_direction", direction);
        }

        Vector2 position = transform.position;
        position.x = position.x + speed * direction * Time.deltaTime;

        
        transform.position = position;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        /*ContactPoint2D cp = collision.GetContact(0);
        if (cp != null)
        {
            Debug.Log("Auch" + collision);
            player.changeHealth(-1);
            //Destroy(gameObject);
        }*/
        Debug.Log("a: " + collision.gameObject.name);


    }
}
