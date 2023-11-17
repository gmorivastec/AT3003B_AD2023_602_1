using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class GUIManagerTarea : MonoBehaviour
{
    // IDEALMENTE SINGLETON
    [SerializeField]
    private Baraja _baraja;

    public void Awake()
    {
        Assert.IsNotNull(_baraja, "BARAJA NO PUEDE SER NULO EN GUIMANAGERTAREA");
    }

    public void Random() 
    {
        _baraja.AleatorizarCartas();
    }

    public void Guardar()
    {
        GuardadoDatosTarea.Instance.Guardar(State.Instance._datos);
    }

    public void Cargar()
    {
        State.Instance.ActualizarDatos((GuardadoDatosTarea.Instance.Cargar() as DatosTarea).posiciones);
    }
}
