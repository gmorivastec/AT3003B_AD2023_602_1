using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Assertions;

public class CartaBehaviour : MonoBehaviour
{
    [SerializeField] public CartaScriptableObject _datos;

    [SerializeField] private TMP_Text _nombreText;
    [SerializeField] private TMP_Text _nivelDeAtaqueText; 

    // Start is called before the first frame update
    void Start()
    {
        Assert.IsNotNull(_datos, "DATOS NO PUEDEN SER NULO EN CARTA BEHAVIOUR");
        Assert.IsNotNull(_nombreText, "TEXT DE NOMBRE NO PUEDE SER NULO EN CARTA BEHAVIOR");
        Assert.IsNotNull(_nivelDeAtaqueText, "TEXT DE NIVEL DE ATAQUE NO PUEDE SER NULO EN CARTA BEHAVIOR");
        _nombreText.text = _datos._nombre;
        _nivelDeAtaqueText.text = _datos._nivelDeAtaque.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
