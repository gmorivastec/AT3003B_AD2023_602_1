using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;

// es posible parametrizar un tipo 
// osea dejarlo abierto a lo que decida un programador posteriormente
// a este mecanismo le llamamos generic
public class GuardadoArchivo<T> : MonoBehaviour
{
    // OJO - manejo de recursos - utilizar singleton
    public static GuardadoArchivo<T> Instance {
        get;
        private set;
    }

    private string _ruta;

    void Awake() 
    {
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
        if(string.IsNullOrEmpty(_ruta)){
            _ruta = Application.persistentDataPath + Path.DirectorySeparatorChar + "guardado.data";
            print(_ruta);
        }

    }

    public void Guardar(T datos) 
    {

        print("GUARDANDO");

        // abrir archivo
        FileStream datosStream = new FileStream(_ruta, FileMode.Create);

        // creamos objeto serializador / deserializador
        BinaryFormatter convertidor = new BinaryFormatter();

        // serializamos objeto en archivo 
        convertidor.Serialize(datosStream, datos);

        // cerramos archivo
        datosStream.Close();
    }


    public object Cargar()
    {

        print("CARGANDO");

        if(File.Exists(_ruta)) {

            // abrir archivos
            FileStream datosStream = new FileStream(_ruta, FileMode.Open);

            // creamos objeto serializador / deserializador
            BinaryFormatter convertidor = new BinaryFormatter();

            // aquí deserializamos
            // de binario -> objeto en memoria
            object datosCargados = convertidor.Deserialize(datosStream);

            datosStream.Close();
            
            return datosCargados;
        }

        return null;
    }
}
