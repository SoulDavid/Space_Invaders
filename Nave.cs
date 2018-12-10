using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Nave : MonoBehaviour {

    
    private Transform player; //Para usar el jugador

    public float nextfire;

    [SerializeField]
    public float speed; //La velocidad de la nave

    [SerializeField]
    private GameObject shot; //El prefab del disparo
    [SerializeField]
    private Transform shotSpawn; //El GameObject donde se pondra el prefab del disparo

    public float fireRate; //La velocidad de disparo

    public float health = 3; //La vida del personaje

    public float maxBorde, minBorde; //En vez, de hacerlo con unos limitadores, simplemente se hace asignandole valores

    [SerializeField]
    private GameObject Vida2;
    [SerializeField]
    private GameObject Vida1;

	
	void Start () {
        player=GetComponent<Transform>();//o simplemente miTransform=transform;
    }
	
	
	void FixedUpdate ()
    {
        float h = Input.GetAxis("Horizontal");

        if (player.position.x < minBorde && h < 0)
            h = 0;
        else if (player.position.x > maxBorde && h > 0)
            h = 0;

        player.position += Vector3.right * h * speed;
    }


    void Update()
    {
        //El disparo: cuando pulsa el espacio se ejecuta esa accion

        if (Input.GetKeyDown("space") && Time.time > nextfire)
        {
            nextfire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);

        }

        //Condicion de derrota: que si llega a 0 esta cambia de escena.
        if(health<=0)
        {
            SceneManager.LoadScene("Defeat");
        }
    }

    //Cuando entra en contacto con un cuerpo
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "EnemyBullet")
        {
            Destroy(other.gameObject);
           
            --health;

            HealthPlayer.a-=1;
            if(health==2)
            {
                Destroy(Vida2);
            }
            else if(health==1)
            {
                Destroy(Vida1);
            }
        }
      
    }
    


}
