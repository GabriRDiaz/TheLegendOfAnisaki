using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepOnLoad : MonoBehaviour
{
    void Start()
    {
        if(!PlayerController.playerCreated){
            DontDestroyOnLoad(this.transform.gameObject);
        }else{
            Destroy(gameObject);
        }
    }

}
