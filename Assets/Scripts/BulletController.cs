using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    Rigidbody2D rb2d;
    public float force = 100f;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.AddForce(Vector2.left * force);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Balazo contra: " + collision.gameObject.name);
        if (collision.gameObject.name == "player")
        {
            Player player = collision.gameObject.GetComponent<Player>();
            if (player != null)
            {
                player.changeHealth(-1);
            }
        }
        Destroy(gameObject);
    }
}
