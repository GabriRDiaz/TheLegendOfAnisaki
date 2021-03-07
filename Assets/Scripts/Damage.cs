using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    /*public float timeToRevive;
    private float timeReviveCounter;
    private bool isReviving;
    private GameObject player;*/
    public int dmg;
    public GameObject canvasDamage;
    void Start()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.name.Equals("Player")){
            //other.gameObject.SetActive(false);
            //isReviving = true;
            //timeReviveCounter = timeToRevive;
            //player = other.gameObject;
            var clone = (GameObject)Instantiate(canvasDamage, //Mismo comportamiento que en WeaponController
                other.gameObject.transform.position,
                Quaternion.Euler(Vector3.zero));
            clone.GetComponent<DmgNumber>().isEnemy = true; 
            clone.GetComponent<DmgNumber>().dmgPoints = dmg; 
    
            other.gameObject.GetComponent<HealthManager>().getDamage(dmg);



        }
    }
    // Update is called once per frame
   /* void Update()
    {
        if(isReviving){
            timeReviveCounter -= Time.deltaTime;
            if(timeReviveCounter<0){
                isReviving = false;
                player.SetActive(true);
            }
        }
    }*/
}
