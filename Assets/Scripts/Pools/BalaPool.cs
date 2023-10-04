using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class BalaPool : MonoBehaviour
{
    // necesitamos singleton-earlo
    public static BalaPool Instance
    {
        get;
        private set;
    } 

    // pool - almacen de objetos que "prestamos" y nos "regresan"
    // se generan en editor o al inicio de ejecución
    // los objetos sólo son habilitados y deshabilitados

    // necesito referencia al original
    [SerializeField] private BalaBehaviour _original;

    // especifico tamaño de pool
    [SerializeField] private int _size = 30;

    // objeto donde vamos a guardar los elementos del pool
    private Queue<BalaBehaviour> _pool;


    // Start is called before the first frame update
    void Start()
    {
        // verificamos que sólo exista uno 
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        // si un objeto puede ser nulo verificarlo ASAP 
        Assert.IsNotNull(_original, "BALA ORIGINAL NO PUEDE SER NULL EN POOL");
        
        // inicializar la pool para poder llenarla 
        _pool = new Queue<BalaBehaviour>();

        // Crear objetos de pool
        for(int i = 0; i < _size; i++)
        {
            GameObject actual = Instantiate(_original.gameObject);
            actual.SetActive(false);

            _pool.Enqueue(actual.GetComponent<BalaBehaviour>());
        }

    }

    public BalaBehaviour GetFromPool(Vector3 position, Quaternion rotation)
    {

        // verificamos que haya al menos 1 elemento en el pool
        if(_pool.Count == 0)
        {
            //Debug.LogError("POOL VACÍA");
            return null;
        }

        // en lugar de crear habilitamos
        BalaBehaviour nuevaBala = _pool.Dequeue();

        // cambiar posición y rotación
        nuevaBala.transform.position = position;
        nuevaBala.transform.rotation = rotation;

        // activamos objeto y regresamos
        nuevaBala.gameObject.SetActive(true);
        return nuevaBala;
    }

    // SIEMPRE que generemos objetos dinámicamente (ya sea con instantiate o con pull)
    // necesitamos una estrategia de destrucción (o de regreso a pool)
    public void ReturnToPool(BalaBehaviour returnedObject)
    {
        _pool.Enqueue(returnedObject);
        returnedObject.gameObject.SetActive(false);
    }
}
