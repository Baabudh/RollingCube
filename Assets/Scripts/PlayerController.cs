using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int speed = 300;
    // Start is called before the first frame update
    void Start()
    {
        if (Input.GetKey(KeyCode.D))
        {
            StartCoroutine(Roll());
        }
    }

    // Update is called once per frame

    IEnumerator Roll()
    {

        float angleToRotate = 90; // Angulo para rotar el cubo

        while (angleToRotate > 0)
        {
            // El angulo donde se va a permitir rotar. Angulo de rotacion. Para que se mueva el cubo
            float angleRotate = Time.deltaTime * speed;
            // Donde se rota el cubo 
            transform.Rotate(angleRotate,0,0);
            // Se encarga de actualizar la cantidad de angulo que queda por rotar, restandoi el angulo rotado (angleRotate) del angulo atotal (angleToRotate).
            angleToRotate = - angleRotate;

            // Para lo corrutina y la vuelve a aempezar cuando sea necesario
            yield return null; 
        }

 
    }
}
