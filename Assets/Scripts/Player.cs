using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //INPUTS
    float horizontal;
    float space;

    Rigidbody2D rb2d;
    AudioSource playerJumping; 

    public int maxHealth = 3;
    int currentHealth;
    

    //INVENCIBLE
    public float timeInvencible = 2f;
    bool isInvencible;
    float invencibleTimer;

    //SALTO
    public float jumpSpeed = 5f;
    bool isJumping;


    // Start is called before the first frame update
    void Start()
    {
        //VIDA
        currentHealth = maxHealth;
        //QualitySettings.vSyncCount = 0;
        //Application.targetFrameRate = 10;

        rb2d = GetComponent<Rigidbody2D>();
        playerJumping = GetComponent<AudioSource>();

        //INVENCIBLE
        isInvencible = false;

        isJumping = false;
    }

    // Update is called once per frame
    void Update()
    {

        horizontal = Input.GetAxis("Horizontal");
        space = Input.GetAxis("Jump");
        //checkMovement();
        checkInvencible();

        Vector2 velocity = rb2d.velocity;
        if (space == 1 && !isJumping)   //&& velocity.y == 0
        {
            playerJumping.Play();
            isJumping = true;
            rb2d.AddRelativeForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
        }

    }

    void FixedUpdate()
    {
        Vector2 velocity = rb2d.velocity;
        velocity.x = 10f * horizontal;
        rb2d.velocity = velocity;
        
    }

   /* void checkMovement()
    {
        //MOVIMIENTO
        //float vertical = Input.GetAxis("Vertical");
        float rotIzq = Input.GetAxis("Fire1");
        float rotDer = Input.GetAxis("Fire2");

        Vector2 position = transform.position;
        position.x = position.x + 10f * horizontal * Time.deltaTime;
        //position.y = position.y + 3f * vertical * Time.deltaTime;

        Quaternion rotation = transform.rotation;
        rotation.z = rotation.z + 0.01f * rotIzq;
        rotation.z = rotation.z - 0.01f * rotDer;

        Debug.Log(rotIzq);

        transform.position = position;
        //transform.rotation = rotation;

    }*/

    void checkInvencible()
    {
        //INVENCIBLE
        if (isInvencible)
        {
            invencibleTimer -= Time.deltaTime;
            if (invencibleTimer <= 0)
            {
                isInvencible = false;
            }
        }
    }

    public void changeHealth(int amount) {

        if (amount < 0)
        {
            if (isInvencible)
            {
                return;
            }
            
            isInvencible = true;
            invencibleTimer = timeInvencible;
        }
        currentHealth += amount;
        if (currentHealth < 0) {
            currentHealth = 0;
        } else if (currentHealth > maxHealth) {
            currentHealth = maxHealth;
        }

        Debug.Log("currentHealth: " + currentHealth);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("a: " + collision.gameObject.tag);

        if (collision.gameObject.tag == "suelo")
        {
            isJumping = false;
        }


    }

}
