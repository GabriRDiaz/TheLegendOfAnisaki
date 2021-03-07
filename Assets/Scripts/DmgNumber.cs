using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DmgNumber : MonoBehaviour
{
    public float dmgSpeed;
    public float dmgPoints;
    public bool isEnemy;
    public Text dmgText;
    /* Este código son transformaciones lineales matemáticas que funcionarían con el texto. No he conseguido implementarlas :(  (Toca seguir estudiando análisis :p)
    public Vector2 direction = new Vector2(1,0);
    public float timeToChangeDirection = 1; //Mismo de siempre
    public float timeToChangeDirectionCounter = 1;
    timeToChangeDirectionCounter -= Time.deltaTime;
        if(timeToChangeDirectionCounter < timeToChangeDirection/2){//Para no completar ciclo entero y volver al centro
            direction *= -1;
            timeToChangeDirectionCounter += timeToChangeDirection; //Se suma la mitad de un lado para hacer el recorrido entero
            //dmgSpeed-=dmgSpeed/1.5f; //Efecto cono
        }
        
       
        this.transform.position = new Vector3(
            this.transform.position.x * direction.x*dmgSpeed*Time.deltaTime, //Movemos la de derecha a izq el texto
            this.transform.position.y * dmgSpeed * Time.deltaTime,
            this.transform.position.z
        );
    */

    // Update is called once per frame
    void Update()
    {
       if(isEnemy){
           dmgText.color = Color.red;
       }
       dmgText.text = "" + dmgPoints;

        this.transform.localScale = this.transform.localScale * (1-Time.deltaTime); //Lo hacemos más pequeño a cada frame
        
    }

}
