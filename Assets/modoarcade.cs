using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class modoarcade: MovimientosSnake
{ 

    int contador , contador_velocidad;
    public Text puntuacion;
    public Text arcade;
    public Text proxNivel;

    public Estrategia nivel;
    public float movimiento = 0.2f;

    public GameObject tailPrefab;

    public Vector2 LimitesVerticales;
    public Vector2 LimitesHorizontales;

    Vector3 UltimaPosicion;

    void Start()
    {
        contador = 0;
        contador_velocidad = 0;
        nivel = new Nivel();
        InvokeRepeating("Move",1 , nivel.getVelocidad());
        InvokeRepeating("DatosPantalla",1 , 0.02f);
        base_datos = new Datos("arcade");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) && (direccion != dir.der))
            direccion = dir.izq;
        if (Input.GetKeyDown(KeyCode.UpArrow) && (direccion != dir.abajo))
            direccion = dir.arriba;
        if (Input.GetKeyDown(KeyCode.RightArrow) && (direccion != dir.izq))
            direccion = dir.der;
        if (Input.GetKeyDown(KeyCode.DownArrow) && (direccion != dir.arriba))
            direccion = dir.abajo;
    }

    void DatosPantalla()
    {
        aumentar_contadores(1);
        puntuacion.text = "Score: " + contador;
        proxNivel.text = "Proxima velocidad(2500): " + contador_velocidad;
        arcade.text = "Record maximo en ARCADE: " + base_datos.getArcade();
    }
    

    void aumentar_contadores(int valor)
    {
        contador += valor;
        contador_velocidad += valor;
        if (contador_velocidad > 2500)
        {
            contador_velocidad = 0;
            CancelInvoke("Move");
            nivel.aumentarVelocidad();
            InvokeRepeating("Move", 0, nivel.getVelocidad());
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Block"))
        {
            print("Juego Terminado " + col.name);
            CancelInvoke("Move");
            CancelInvoke("DatosPantalla");
            if (contador > base_datos.getArcade())
                base_datos.setArcade(contador);
            SceneManager.LoadScene("Fin");
        }
        else if (col.CompareTag("Food"))
        {
            ListaSnake.Add(Instantiate(tailPrefab, ListaSnake[ListaSnake.Count - 1].position, Quaternion.identity).transform);
            col.transform.position = new Vector2(Random.Range(LimitesHorizontales.x, LimitesHorizontales.y), Random.Range(LimitesVerticales.x, LimitesVerticales.y));
            aumentar_contadores(400);
        }
    }
}
