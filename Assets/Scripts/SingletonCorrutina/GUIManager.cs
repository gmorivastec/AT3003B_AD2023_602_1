using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Assertions;

public class GUIManager : MonoBehaviour
{

    // con los atributos tratar de ser lo más restrictivo posible 
    // OJO - ESTO PUEDE DETONAR UN NULL REFERENCE EXCEPTION
    [SerializeField] private TMP_Text _textUI;

    // Start is called before the first frame update
    void Start()
    {
        // recomendación para mitigar el problema de los 
        // null reference exception - checar ASAP
        Assert.IsNotNull(_textUI, "TEXT UI NULO EN GUI MANAGER, FAVOR DE VERIFICAR");
    }

    // Update is called once per frame
    void Update()
    {
        _textUI.text = GameStateBehaviour.Instance.Vida + "";   
    }
}
