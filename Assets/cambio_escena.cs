using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;

public class cambio_escena : MonoBehaviour
{
    public void CambiarEscena(string name)
    {
        SceneManager.LoadScene(name);
    }
}
