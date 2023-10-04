using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//camel case
// idioms 

// definimos una clase
public class GameStateBehaviour : MonoBehaviour
{
    // attributes / variables
    
    [SerializeField] private float _vida = 100;

    // scope 

    // properties
    // mecanismo que divide quién puede leer y quién puede escribir una variable
    public float Vida{
        get {
            return _vida;
        }
        private set {
            _vida = value;
        }
    }

    // singleton - mecanismo que evita la creación de más de una instancia
    // de un tipo

    // paso 1 - definición de la instancia
    // static - miembro de la clase que es SÓLO UNO para todas las instancias
    // de la clase
    public static GameStateBehaviour Instance{
        get;
        private set;
    }

    void Awake() 
    {
        // verificar lo antes posible que sólo exista 1 instancia de este tipo
        // tradicionalmente un singleton EVITA la creación de nuevos objetos
        // aquí no es posible pero vamos a borrar los nuevos si es que hay  
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }      

        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        // EJEMPLOS
        // variable 
        //_vida = 5;
        // Propiedad
        //Vida = 10;
    }

    // sin "caracteres especiales" 
    // no ASCII
    public void RecibirDanio()
    {
        _vida -= 10;
        // _vida = _vida - 10;
    }
}
