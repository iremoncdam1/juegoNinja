using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{

    GameObject jugador;

    // Start is called before the first frame update
    void Start()
    {
        jugador = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 jugadorPos = jugador.transform.position;
        Vector3 camaraPos = transform.position;
        camaraPos.x = jugadorPos.x;
        camaraPos.y = jugadorPos.y;
        transform.position = camaraPos;
    }
}
