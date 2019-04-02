using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Datos
{
    int arcademax;
    int snakemax;
    string pathArcade;
    string pathSnake;

    public Datos(string tipo_juego)
    {
        if (tipo_juego == "arcade") {
            arcademax = 0;
             //Path del archivo
            pathArcade = Application.dataPath + "/DatosArcade.txt";
             //Crea el archivo, si es que no existe
            if (!File.Exists(pathArcade))
                 File.WriteAllText(pathArcade, arcademax + " - es la mejor puntuacion arcade");
            else
                recuperar_arcademax();
        }
        if (tipo_juego == "nivel1")
        {
            snakemax = 0;
            //Path del archivo
            pathSnake = Application.dataPath + "/DatosSnake.txt";

            //Crea el archivo, si es que no existe
            if (!File.Exists(pathSnake))
                File.WriteAllText(pathSnake, snakemax + " - es la mejor puntuacion en modo snake");
            else
                recuperar_snakemax();
        }
        if (tipo_juego == "nivel2")
        {
            snakemax = 0;
            //Path del archivo
            pathSnake = Application.dataPath + "/DatosSnake2.txt";

            //Crea el archivo, si es que no existe
            if (!File.Exists(pathSnake))
                File.WriteAllText(pathSnake, snakemax + " - es la mejor puntuacion en modo snake");
            else
                recuperar_snakemax();
        }


    }
    private void recuperar_arcademax()
    { 
        string Texto = File.ReadAllText(pathArcade);
        string obtener_numero = Texto.Remove(Texto.Length - 32);
        arcademax = int.Parse(obtener_numero);
    }
    private void recuperar_snakemax()
    {
        string Texto = File.ReadAllText(pathSnake);
        string obtener_numero = Texto.Remove((Texto.Length - 39));
        snakemax = int.Parse(obtener_numero);
    }

    public void setArcade(int i)
    {
        arcademax = i;
        File.WriteAllText(pathArcade, arcademax + " - es la mejor puntuacion arcade");
        recuperar_arcademax();
    }
    public void setSnake (int i)
    { 
        snakemax = i;
        File.WriteAllText(pathSnake, snakemax + " - es la mejor puntuacion en modo snake");
        recuperar_snakemax();
    }
    public int getArcade()
    {
        return arcademax;
    }

    public int getSnake()
    {
        return snakemax;
    }
}