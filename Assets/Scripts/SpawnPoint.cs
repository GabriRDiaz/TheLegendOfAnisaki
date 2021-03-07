using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    private PlayerController player;
    private CameraScript cameraVar;
    public Vector2 facingDir = Vector2.zero;

    public string uuid;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>(); //Al ser el único objeto con este script funciona
        cameraVar = FindObjectOfType<CameraScript>();

        if(!player.nextUUID.Equals(uuid)){return;} //Comprueba que el uuid coincide con el que se ha de hacer tp

        player.transform.position = this.transform.position;
        cameraVar.transform.position = new Vector3(transform.position.x,
        transform.position.y,
        cameraVar.transform.position.z); //Mantenemos la Z en -10
        player.lastMove = facingDir;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
