using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public int dmg;
    
    public GameObject bloodAnim;
    public GameObject canvasDamage;
    private GameObject hitPoint;
    private void Start() {
        hitPoint = transform.Find("HitPoint").gameObject; //Lo busca entre los hijos
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag.Equals("Enemy")){
            if(hitPoint!=null){
                Destroy(Instantiate(bloodAnim, hitPoint.transform.position, hitPoint.transform.rotation), 0.5f); //Aquí la sangre sale con la espada por la rotación
            }
             var clone = (GameObject)Instantiate(canvasDamage,
                                                 hitPoint.transform.position,
                                                 Quaternion.Euler(Vector3.zero));//Aquí coon el Quaternion mira siempre hacia arriba
            //Debug.Log(hitPoint.transform.position);
            //clone.transform.SetParent(transform.Find("HitPoint").transform);
           
            clone.GetComponent<DmgNumber>().dmgPoints = dmg;

            other.gameObject.GetComponent<HealthManager>().getDamage(dmg);
        }
    }

}
