using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public abstract class modosnake : MovimientosSnake
{

    protected string nivel;
    public Text snake_max;
    public float velocidad = 0.05f;

    public Text text_reloj;
    public int contador;

    public Vector2 verticalLimits;
    public Vector2 horizontalLimits;
     

    void datos_pantalla()
    {
        text_reloj.text = "Reloj: " + contador;
        contador += 1;
        snake_max.text = "Maxima puntuacion: " + base_datos.getSnake();
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
        if (Input.GetKeyDown(KeyCode.E))
            acelerar();
        if (Input.GetKeyDown(KeyCode.R))
            normalizar();
    }

    //Implementacion de metodos de velocidad de personaje SNAKE
    void acelerar()
    {
        velocidad = 0.03f;
        CancelInvoke("Move");
        InvokeRepeating("Move", 0, velocidad);
    }

    void normalizar()
    {
        velocidad = 0.06f;
        CancelInvoke("Move");
        InvokeRepeating("Move", 0, velocidad);
    }
}
