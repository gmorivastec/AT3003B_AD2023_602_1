using UnityEngine;
using System;

// VAMOS A SERIALIZAR!

// sabemos que tiene que ver con modificar un dato para hacerlo visible en editor
// (sólo se muestran datos serializables)

// SERIALIZAR: PROCESO QUE TRANSFORMA UN OBJETO 
// A UNA REPRESENTACIÓN QUE SE PUEDE GUARDAR / TRANSMITIR

// puede ser un XML, JSON, binario

// OJO: NO ESTÁ CIFRADO

[Serializable]
public class Datos 
{
    public int vida;
    public int experiencia;
    public string nombre;
    public float[] posicion;
}
