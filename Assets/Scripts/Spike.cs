using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Yo objeto " + collision);

        Player player = collision.GetComponent<Player>();
        if (player != null)
        {
            player.changeHealth(-1);
            Destroy(gameObject);
        }
    }
}
