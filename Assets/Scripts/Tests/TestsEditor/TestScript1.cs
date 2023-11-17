using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Ejemplito2;
using UnityEngine.Assertions;

// las pruebas unitarias son muy utilizadas en metodologías como TDD 
// (test driven development)
// https://en.wikipedia.org/wiki/Test-driven_development
public class TestScript1
{

    private AssemblyTest2 assemblyTest2;

    // no hay awake, no hay start
    // PERO tenemos algo más básico llamado constructor
    // sintaxis: public MismoNombreQueClase(listaDeParametros) // NO TIENE TIPO DE RETORNO
    // se corre ANTES que todo lo demás!
    public TestScript1()
    {
        GameObject go = GameObject.Find("AssemblyTest2");
        assemblyTest2 = go.GetComponent<AssemblyTest2>();
    }

    // A Test behaves as an ordinary method
    [Test]
    public void Suma()
    {
        // como hacer pruebas unitarias 
        // comparamos resultado obtenido vs resultado esperado
        UnityEngine.Assertions.Assert.AreEqual(5, assemblyTest2.Suma(2, 3));
        UnityEngine.Assertions.Assert.AreEqual(-1, assemblyTest2.Suma(2, -3));
        UnityEngine.Assertions.Assert.AreEqual(-5, assemblyTest2.Suma(-2, -3));

    }

    [Test]
    public void Resta()
    {
        // Use the Assert class to test conditions
        UnityEngine.Assertions.Assert.AreEqual(-1, assemblyTest2.Resta(2, 3));
        UnityEngine.Assertions.Assert.AreEqual(2, assemblyTest2.Resta(5, 3));
        UnityEngine.Assertions.Assert.AreEqual(1, assemblyTest2.Resta(-2, -3));
    }

    [Test]
    public void Multiplicacion()
    {
        // Use the Assert class to test conditions
        UnityEngine.Assertions.Assert.AreEqual(6, assemblyTest2.Multiplicacion(-2, -3));
    }

    [Test]
    public void Division()
    {
        // Use the Assert class to test conditions
        UnityEngine.Assertions.Assert.AreEqual(2, assemblyTest2.Division(6, 3));
    }

    
}
