using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Final : MonoBehaviour
{
    public void CerrarJuego()
    {
        Application.Quit();
        Debug.Log("Cerrar el juego");
    }
}
