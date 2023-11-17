// cuando queremos usar código de otro "lado" utilizamos la instrucción "using"
// qué es ese "lado" ?
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

// RECOMENDACIÓN PARA LA VIDA:
// SI USAN ASSEMBLIES ASEGÚRENSE QUE TODOS SUS SCRIPTS PERTENEZCAN A UN ASSEMBLY QUE NO SEA
// EL DEFAULT

// concepto - namespace
// es un conjunto de clases interrelacionadas - que comparten / abordan el mismo tipo de lógica

// sintaxis
/* 
namespace NombreDeNamespace {
    class Clase {
    }
} 
*/

// varios archivos distintos pueden hacer referencia al mismo namespace
namespace Ejemplito1{
    public class AssemblyTestBehaviour : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            print("HOLA DESDE EL ASSEMBLY!");
        }

        // Update is called once per frame
        void Update()
        {
            
        }
    }

    class Ejemplote 
    {

    }
}
