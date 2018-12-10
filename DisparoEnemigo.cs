using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoEnemigo : MonoBehaviour {
    

    private float velocidad;
    private Transform disparo;

    void Start()
    {
        velocidad = 7f;
        disparo = transform;

    }
	void FixedUpdate () {
        disparo.position += new Vector3(0, -1, 0) * velocidad * Time.deltaTime;

        if (disparo.position.y <= -5)
            Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
        
    }



}
