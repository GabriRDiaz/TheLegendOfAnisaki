using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Warp : MonoBehaviour
{
    public string goTo = "Scene";
    public string uuid;
    public bool click = false;
        private void OnTriggerEnter2D(Collider2D other) {
               Teleport(other.gameObject.name);
        }
    private void OnTriggerStay2D(Collider2D other) {
                Teleport(other.gameObject.name);
    }

    private void Teleport(string objName){
        if(objName =="Player"){
            if(!click || (click && Input.GetKeyDown("q"))){
                SFXManager.SharedInstance.PlaySound(SFXType.SoundType.DOOR);
                FindObjectOfType<PlayerController>().nextUUID = uuid;
                SceneManager.LoadScene(goTo);
        }
        }
    }
}
