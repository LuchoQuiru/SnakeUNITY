﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptLevel1 : modosnake
{
    void Start()
    {
        base_datos = new Datos("nivel1");
        InvokeRepeating("Move", 1, velocidad);
        InvokeRepeating("datos_pantalla", 0, 1);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Block"))
        {
            print("Juego Terminado " + col.name);
            UnityEngine.SceneManagement.SceneManager.LoadScene("Fin");
        }
        else if (col.CompareTag("Food"))
        {
            if (contador < base_datos.getSnake())
                base_datos.setSnake(contador);
            UnityEngine.SceneManagement.SceneManager.LoadScene("SnakeNivel2");
        }
 
    }
}
