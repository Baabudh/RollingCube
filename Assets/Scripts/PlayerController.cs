using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool _isMoving;
    [SerializeField] private float _rollspeed = 3; // Velocidad de giro, para que se mueva

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        /* Aca verificamos si "_isMoving" es verdadero por loq ue la funcion sale temprano y no hace nada.
        Y asi impedimos que pase algo si ya se esta moviendo el cubo. si ya stamos moviendonos regresamos  a nustra funcion de actualizacion si nos estamos moviendo  */
        if (_isMoving) return;

        if (Input.GetKeyDown(KeyCode.A)) Assemble(Vector3.left);
        else if (Input.GetKey(KeyCode.D)) Assemble(Vector3.right);
        else if (Input.GetKey(KeyCode.W)) Assemble(Vector3.forward);
        else if (Input.GetKey(KeyCode.S)) Assemble(Vector3.back);

        void Assemble(Vector3 dir)
        {
            // obtener el punto de anclaje del ancho.Se hace esto poruqe si lo rotas desde el ceentro gira en su mismo eje y no se mueve por lo que hay que desplazar el pivote o anclaje al costado
            var anchor = transform.position + (Vector3.down + dir) * 0.5f;

            /* Aca creamos una variable de nustrao eje para saber que eje va agirar el cubo <(el z, x o y). Hcenos esto para sacar el eje z debido a que con vector cros le lasos un
             hacia arriba y havia la izqueirda y por ser perpendicular nos entrega el eje z. (que necesitamos para rotarlo en su eje z)*/
            var axis = Vector3.Cross(Vector3.up, dir);

            // Par que empieze la corrrutina
            StartCoroutine(Roll(anchor, axis));
        }
    }

    IEnumerator Roll(Vector3 anchor, Vector3 axis)
    {
        _isMoving = true;

        for (int i = 0; i < (90 / _rollspeed); i++)
        {
            // ESTA ES LA FUNCION QUE HCE ROTAR EL CUBO. Toma el punto de anclaje alrededor del cual rotar (anchor), el eje de rotación (axis) y el ángulo de rotación (_rollspeed).
            transform.RotateAround(anchor, axis, _rollspeed); 

            // Para que no suceda todo a la vez, si no que espere 0.01f segundos
            yield return new WaitForSeconds(0.01f); 
        }

        _isMoving = false; // Indica que el cubo a terminado de moverse 

    }
}
