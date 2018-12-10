using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorEnemigos : MonoBehaviour
{

    [SerializeField]
    private GameObject prefabinvader;
    [SerializeField]
    private GameObject prefabinvader2;
    [SerializeField]
    private GameObject prefabinvader3;

    GameObject nuevoinvader;
    public byte puntuacion;
    public byte invadersvivos = 36;
    MovimientoEnemigos scriptmovimientoenemigos;

    public GameObject[,] invaders = new GameObject[6, 6];
    public float firerate;
    public float siguientedisparo;

    byte filaaleatoria;
    byte columnaaleatoria;

    byte contador;

    private static ControladorEnemigos _instance;
    public static ControladorEnemigos instance
    {
        get
        {
            return _instance;
        }
    }

    void Awake()
    {
        if (_instance == null)
            _instance = this;
        else
            Destroy(gameObject);


    }


    void Start()
    {
        Rellenar();
        Pintar();
        firerate = 0.8f;
    }


    void FixedUpdate()
    {

        filaaleatoria = (byte)Random.Range(0, 6);
        columnaaleatoria = (byte)Random.Range(0, 6);

        if (Time.time > siguientedisparo && Disparar(filaaleatoria,columnaaleatoria) == true)
        {
            siguientedisparo = Time.fixedTime + firerate;
            invaders[filaaleatoria, columnaaleatoria].GetComponent<MovimientoEnemigos>().Disparar();
        }
        else
        {
            filaaleatoria = (byte)Random.Range(0, 6);
            columnaaleatoria = (byte)Random.Range(0, 6);
            Disparar(filaaleatoria, columnaaleatoria);
        }

        for (byte i = 0; i < invaders.GetLength(0); ++i)
        {
            for (byte j = 0; j < invaders.GetLength(1); ++j)
            {
                if (invaders[i, j] != null && invaders[i, j].GetComponent<MovimientoEnemigos>().LanzaRayo() == true)// && )
                {
                        Comprobar();
                        CambiarDireccion();
                   
                   

                }


            }
        }
    }

    public void CambiarDireccion()
    {

        for (byte i = 0; i < invaders.GetLength(0); ++i)
        {
            for (byte j = 0; j < invaders.GetLength(1); ++j)
            {
                if (invaders[i, j] != null)
                    invaders[i, j].GetComponent<MovimientoEnemigos>().Cambiardireccion();

            }
        }

    }


    public void Comprobar()
    {
        for (byte i = 0; i < invaders.GetLength(0); ++i)
        {
            for (byte j = 0; j < invaders.GetLength(1); ++j)
            {

                if (invaders[i, j] != null)
                invaders[i, j].GetComponent<MovimientoEnemigos>().ComenzarBajar();

            }
        }


    }


    void Rellenar()
    {

        for (byte fila = 0; fila < invaders.GetLength(0); ++fila)
        {
            for (byte columna = 0; columna < invaders.GetLength(1); ++columna)
            {

                invaders[fila, columna] = nuevoinvader;


            }
        }
    }

    void Pintar()
    {
        for (byte fila = 0; fila < invaders.GetLength(0); ++fila)
        {
            for (byte columna = 0; columna < invaders.GetLength(1); ++columna)
            {
                if (columna == 0 || columna == 3 || columna == 6)
                {
                    invaders[fila, columna] = Instantiate(prefabinvader);


                }
                else if (columna == 1 || columna == 4)
                {
                    invaders[fila, columna] = Instantiate(prefabinvader2);

                }
                else
                {
                    invaders[fila, columna] = Instantiate(prefabinvader3);

                }
                invaders[fila, columna].transform.position = new Vector2(-2.35f + fila * 1.2f, -0.9f + columna);
                scriptmovimientoenemigos = (MovimientoEnemigos)invaders[fila, columna].GetComponent(typeof(MovimientoEnemigos));
                scriptmovimientoenemigos.ComenzarMovimientoCorrutina();

            }

        }

    }




    bool Disparar(byte fila, byte columna)
    {
       
            if (invaders[ fila,columna ] != null)
            return true;
            
            else
            return false;
            
        
       
       
        
    }

}
   



