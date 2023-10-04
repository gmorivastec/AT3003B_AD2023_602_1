using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineBhaviour : MonoBehaviour
{

    // el motor tiene un flujo principal de ejecución

    // coroutina - flujo paralelo de ejecución 
    // pseudo concurrencia

    // las corutinas están asociadas con el componente que las ejecuta
    // la adminstración de las corrutinas corresponde al componente dueño

    private Coroutine _corrutina;
    private IEnumerator _iEnumerator;

    // Start is called before the first frame update
    void Start()
    {
        // como se ejecuta una corutina
        _iEnumerator = HolaRecurrente();
        
        StartCoroutine(DecirHola());
        _corrutina = StartCoroutine(_iEnumerator);
        StartCoroutine("HolaRecurrente");
    }

    // Update is called once per frame
    void Update()
    {
        // tener el update más magro posible
        // qué cosas sí poner
        // - user input
        // - movimiento 

        if(Input.GetKeyUp(KeyCode.Y)){
            // detener todas las corrutinas
            StopAllCoroutines();
        }

        // opción 2 - detener corrutina específica
        // para ello necesitamos una referencia a esa corrutina
        if(Input.GetKeyUp(KeyCode.U)){
            StopCoroutine(_iEnumerator);
        }

        if(Input.GetKeyUp(KeyCode.I)){
            StopCoroutine(_corrutina);
        }

        if(Input.GetKeyUp(KeyCode.O)){
            StopCoroutine("HolaRecurrente");
        }
    }

    // definir una corrutina
    // las corrutinas se definen por medio de un método
    IEnumerator DecirHola()
    {
        yield return new WaitForSeconds(3);
        print("HOLA!");
    }

    IEnumerator HolaRecurrente()
    {
        
        while(true){
            
            print("HOLA RECURRENTE");
            yield return new WaitForSeconds(1);
        }
        
        
    }
}
