using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoEnemigos : MonoBehaviour {

    public bool direccion;
    private Transform marcianito;
    [SerializeField]
    private float velocidad = 0.5f;

    private Coroutine corrutinamovimiento;
    public Coroutine corrutinabajar;
  
    Rigidbody2D rb;
    [SerializeField]
    private Transform sensor;
    [SerializeField]
    private Transform sensor2;
    [SerializeField]
    private Transform puntodisparo;
    [SerializeField]
    private GameObject disparo;


    public RaycastHit2D rayo;
    public RaycastHit2D rayo2;


  

    void Awake()
    {

        direccion = true;
        marcianito = transform;
        rb = (Rigidbody2D)GetComponent(typeof(Rigidbody2D));

    }

    void FixedUpdate() {
      
    }

    
    private IEnumerator Movimiento()
    {
       while (true)
       {
            if (direccion)
                marcianito.position += new Vector3(1, 0, 0) * velocidad;
           
            
            
            else
                marcianito.position += new Vector3(-1, 0, 0) * velocidad;

         

            yield return new WaitForSeconds(1f);
       }
      
    }
    
    private IEnumerator Bajar()
    {
        yield return new WaitForSeconds(0.5f);
        marcianito.transform.position += new Vector3(0, -1, 0);
       
    }




    public void Disparar()
    {
        Debug.Log("Disparo");      
        GameObject nuevodisparo = Instantiate(disparo);
        nuevodisparo.transform.position = puntodisparo.position;
       
    }



    public void ComenzarMovimientoCorrutina()
    {
       
        if (corrutinamovimiento == null)
        {
            corrutinamovimiento = StartCoroutine(Movimiento());
            
        }

    }

    public void ComenzarBajar()
    {

        if (corrutinabajar == null)
        {
            corrutinamovimiento = StartCoroutine(Bajar());

        }
        Debug.Log("CORRUTINA BAJAR INICIADA");
    }




    public void PararMovimientoCorrutina()
    {
     
            StopCoroutine(corrutinamovimiento);
            corrutinamovimiento = null;
        
           
    }

    public void PararCorrutinaBajar()
    {
            StopCoroutine(corrutinabajar);
            corrutinabajar = null;
        Debug.Log("CORRUTINA BAJAR PARADA");
    }



    public bool LanzarRayoDerecha()
    {
       
        rayo = Physics2D.Raycast(sensor.position, Vector2.right, 0.1f);
        Debug.DrawRay(sensor.position, Vector2.right, Color.blue);
        if (rayo.collider != null && rayo.collider.tag == "limite")
        {
           return true;
            //ComenzarBajar();
            //direccion = false;

        }
        else
        {
            return false;
            /*
            if(corrutinabajar != null)
            {
                PararCorrutinaBajar();
            }
            hayalgo = false;*/
        }
           

    }

        public bool LanzarRayoIzquierda()
    {
       
        rayo2 = Physics2D.Raycast(sensor2.position, Vector2.left, 0.1f);
        Debug.DrawRay(sensor2.position, Vector2.left, Color.red);
        if (rayo2.collider != null  && rayo2.collider.tag == "limite")
        {
            return true;
           // ComenzarBajar(); 
           
           // direccion = true;
        }
        else
        {
            return false;
        }
        
     }

    public bool LanzaRayo()
    {
        if (direccion)
        {
            if (LanzarRayoDerecha())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            if (LanzarRayoIzquierda())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
      
    }


  public void Cambiardireccion()
    {
        direccion = !direccion;

    }
}

