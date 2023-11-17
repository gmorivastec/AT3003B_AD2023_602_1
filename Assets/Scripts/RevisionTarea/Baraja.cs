using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Events;

public class Baraja : MonoBehaviour
{

    [Serializable]
    public class PosicionesActualizadas : UnityEvent<int[]> {}

    // referencia a todos los posibles scriptableobjects que
    // podemos utilizar 
    [SerializeField]
    private CartaScriptableObject[] _cartasDisponibles;

    [SerializeField]
    private CartaBehaviour[] _cartasEnTablero;

    [SerializeField]
    private PosicionesActualizadas _posicionesActualizadas;

    // Start is called before the first frame update
    void Awake()
    {
        Assert.AreNotEqual(
            0, 
            _cartasDisponibles.Length, 
            "SE REQUIERE AL MENOS 1 CARTA DISPONIBLE"
        );
        Assert.AreNotEqual(
            0, 
            _cartasEnTablero.Length, 
            "SE REQUIERE AL MENOS 1 CARTA EN TABLERO"
        ); 

        AleatorizarCartas();
    }

    // si hay lógica que se utiliza en más de un lugar 
    // EVITA un famoso antipatrón:
    // copy-paste programming
    // https://en.wikipedia.org/wiki/Copy-and-paste_programming

    // si voy a copipeistear evaluar si no puedo:
    // - declarar una función con esa lógica
    // - heredar de una superclase con esa lógica

    public void AleatorizarCartas()
    {
        print("RANDOMIZING");
        // sintaxis de foreach
        // foreach(tipoDeDato nombreVariable in ColeccionARecorrer)
        int[] resultado = new int[_cartasEnTablero.Length];
        int i = 0;
        foreach(CartaBehaviour cartaActual in _cartasEnTablero) 
        {
            int posRandom = UnityEngine.Random.Range(0, _cartasDisponibles.Length);
            
            // ahorita sólo agarra una carta random de las ya existentes
            // si no quieres repeticiones hay que hacer un shuffle
            // https://en.wikipedia.org/wiki/Fisher%E2%80%93Yates_shuffle
            cartaActual.ActualizarDatos(_cartasDisponibles[posRandom]);

            // ir guardando resultado
            resultado[i] = posRandom;
            i++;
        }

        _posicionesActualizadas.Invoke(resultado);
    }
}
