using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientosSnake : MonoBehaviour
{
    protected enum dir
    {
        arriba,
        abajo,
        der,
        izq,
        fast,
        normal
    }

    protected Datos base_datos;
    Vector3 lastPos;
    public float stepRate;
    protected dir direccion;
    public List<Transform> ListaSnake;

    //Implementacion del movimiento del personaje SNAKE
    void Move()
    {
        lastPos = transform.position;

        Vector3 nextPos = Vector3.zero;

        if (direccion == dir.abajo)
            nextPos = Vector2.down;
        else if (direccion == dir.izq)
            nextPos = Vector2.left;
        else if (direccion == dir.arriba)
            nextPos = Vector2.up;
        else if (direccion == dir.der)
            nextPos = Vector2.right;

        nextPos *= stepRate;
        transform.position += nextPos;

        MoveTail();
    }


    void MoveTail()
    {
        for (int i = 0; i < ListaSnake.Count; i++)
        {
            Vector3 temp = ListaSnake[i].position;
            ListaSnake[i].position = lastPos;
            lastPos = temp;
        }
    }
}
