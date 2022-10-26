using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {

        Player player = collision.GetComponent<Player>();
        if (player != null)
        {
            Debug.Log("Me corto" + collision);
            player.changeHealth(-1);
            //Destroy(gameObject);
        }
    }
}
