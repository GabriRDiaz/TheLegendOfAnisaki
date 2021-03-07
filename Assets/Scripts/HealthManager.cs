using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int maxHealth;
    [SerializeField] //Para ver la variable desde el editor
    private int currentHealth;
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void getDamage(int dmg){
        if(gameObject.name.Equals("Player")){
                SFXManager.SharedInstance.PlaySound(SFXType.SoundType.DAMAGED);
            }else{
                SFXManager.SharedInstance.PlaySound(SFXType.SoundType.ATTACK);
            }
        currentHealth-=dmg;
        if(currentHealth<=0){
            if(gameObject.name.Equals("Player")){
                SFXManager.SharedInstance.PlaySound(SFXType.SoundType.DIE);
            }
            gameObject.SetActive(false);
        }
    }
    public void increaseMaxHp(int newMaxHealth){
        maxHealth = newMaxHealth;
        currentHealth = maxHealth;
    }
    public int GetCurrentHealth(){
        return currentHealth;
    }
}
