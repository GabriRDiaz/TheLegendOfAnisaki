using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 1;
    private Rigidbody2D _rb2d;
    private bool isMoving;

    //Tiempo entre pasos
    public float timeBetweenSteps; 
    private float timeBetweenStepsCounter; 
    //Tiempo que tarda en dar lospasos
    public float timeToMakeStep;
    private float timeToMakeStepCounter;
    public Vector2 directionMove;
    void Start(){
        _rb2d = GetComponent<Rigidbody2D>();
        timeBetweenStepsCounter = timeBetweenSteps*Random.Range(0.5f,1.5f); //Añadimos aleatoriedad al inicio
        timeToMakeStepCounter = timeToMakeStep*Random.Range(0.5f,1.5f); 
    }

    // Update is called once per frame
    void Update(){
        if(isMoving){
                timeToMakeStepCounter -= Time.deltaTime; //Restamos al Counter el tiempo que tarda en hacer anim.
                _rb2d.velocity = directionMove*speed;
                if(timeToMakeStepCounter<0){ //Si se termina el tiempo deja de moverse
                    isMoving = false; 
                    timeBetweenStepsCounter = timeBetweenSteps; //Reiniciamos el contador
                    _rb2d.velocity = Vector2.zero; //Detenemos al enemigo
                }
        }else{
                timeBetweenStepsCounter -= Time.deltaTime; //Lo mismo en caso de no estar en mov.
                if(timeBetweenStepsCounter<0){ //Misma condición, pero en parada
                    isMoving = true; 
                    timeToMakeStepCounter = timeToMakeStep; //Reiniciamos el contador
                   directionMove = new Vector2(Random.Range(-1,2), Random.Range(-1,2)); //Dir aleatoria
                }
        }
    }
}
