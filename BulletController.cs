using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    private Transform bullet;
    public float speed;

	// Use this for initialization
	void Start () {
        bullet = GetComponent<Transform>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        bullet.position += Vector3.up * speed;

        if (bullet.position.y >= 10)
            Destroy(gameObject);
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        else if (other.gameObject.name == "Base")
        {
            Destroy(gameObject);
        }


    }
}
