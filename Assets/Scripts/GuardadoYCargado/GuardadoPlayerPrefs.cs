using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardadoPlayerPrefs : MonoBehaviour
{

    private readonly string NOMBRE = "nombre";
    private readonly string EDAD = "edad";
    private readonly string PESO = "peso";

    [SerializeField]
    private string _nombre;
    
    [SerializeField]
    private int _edad;

    [SerializeField]
    private float _peso;

    public static GuardadoPlayerPrefs Instance {
        get;
        private set;
    }

    void Awake() 
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    public void Guardar() 
    {
        print("GUARDANDO PLAYERPREFS");
        PlayerPrefs.SetString(NOMBRE, _nombre);
        PlayerPrefs.SetInt(EDAD, _edad);
        PlayerPrefs.SetFloat(PESO, _peso);
    }

    public void Leer() 
    {
        if(PlayerPrefs.HasKey(NOMBRE)) _nombre = PlayerPrefs.GetString(NOMBRE);
        if(PlayerPrefs.HasKey(EDAD)) _edad = PlayerPrefs.GetInt(EDAD);
        if(PlayerPrefs.HasKey(PESO)) _peso = PlayerPrefs.GetFloat(PESO);
    }
}
