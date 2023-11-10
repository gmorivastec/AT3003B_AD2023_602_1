using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.Assertions;

public class Baraja : MonoBehaviour
{

    // referencia a todos los posibles scriptableobjects que
    // podemos utilizar 
    [SerializeField]
    private CartaScriptableObject[] _cartasDisponibles;

    [SerializeField]
    private CartaBehaviour[] _cartasEnTablero;

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

        // sintaxis de foreach
        // foreach(tipoDeDato nombreVariable in ColeccionARecorrer)
        foreach(CartaBehaviour cartaActual in _cartasEnTablero) 
        {
            // ahorita sólo agarra una carta random de las ya existentes
            // si no quieres repeticiones hay que hacer un shuffle
            // https://en.wikipedia.org/wiki/Fisher%E2%80%93Yates_shuffle
            cartaActual._datos = 
            _cartasDisponibles[Random.Range(0, _cartasDisponibles.Length)];
        }
    }
}
