using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject target;
   public float camSpeed; // = Velocidad jugador
   private Vector3 tPos;
   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tPos = new Vector3(target.transform.position.x,
                            target.transform.position.y,
                            this.transform.position.z);
    }
    private void LateUpdate() {
        //Interpolación lineal de los vectores --> Suaviza el desplazamiento
        this.transform.position = Vector3.Lerp(this.transform.position,
                                                tPos,
                                                camSpeed*Time.deltaTime);
    }
}
