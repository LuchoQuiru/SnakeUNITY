using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nivel : Estrategia
{
    private float velocidad = 0.07f;

    public Nivel()
    {
    }

    float Estrategia.getVelocidad()
    {
        return velocidad;
    }

    void Estrategia.aumentarVelocidad()
    {
        velocidad -= 0.005f;
    }
    
}
