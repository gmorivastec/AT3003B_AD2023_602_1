using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class GuardadoArchivo : MonoBehaviour
{
    // OJO - manejo de recursos - utilizar singleton
    public static GuardadoArchivo Instance {
        get;
        private set;
    }

    public Datos _datos;
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

        _datos = Cargar();
    }

    public void Guardar() 
    {

        print("GUARDANDO");

        // abrir archivo
        FileStream datosStream = new FileStream(_ruta, FileMode.Create);

        // creamos objeto serializador / deserializador
        BinaryFormatter convertidor = new BinaryFormatter();

        // serializamos objeto en archivo 
        convertidor.Serialize(datosStream, _datos);

        // cerramos archivo
        datosStream.Close();
    }

    public Datos Cargar()
    {

        print("CARGANDO");

        if(File.Exists(_ruta)) {

            // abrir archivo
            FileStream datosStream = new FileStream(_ruta, FileMode.Open);

            // creamos objeto serializador / deserializador
            BinaryFormatter convertidor = new BinaryFormatter();

            // aquí deserializamos
            // de binario -> objeto en memoria
            Datos datosCargados = convertidor.Deserialize(datosStream) as Datos;

            datosStream.Close();
            
            return datosCargados;
        }

        return new Datos();
    }
}
