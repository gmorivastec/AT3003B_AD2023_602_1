using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour
{

    public static State Instance {
        get;
        private set;
    }
    
    public DatosTarea _datos;
    
    public void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        _datos = new DatosTarea();
    }

    public void ActualizarDatos(int[] posiciones)
    {
        _datos.posiciones = posiciones;
    }
}
