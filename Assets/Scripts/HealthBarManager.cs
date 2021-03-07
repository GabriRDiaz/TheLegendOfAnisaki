using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
public class HealthBarManager : MonoBehaviour
{
    public Slider playerHealthBar;
    public Text playerHealthText;
    public HealthManager playerHealthManager;

    void Update(){
        playerHealthBar.maxValue = playerHealthManager.maxHealth;
        playerHealthBar.value = playerHealthManager.GetCurrentHealth();

        StringBuilder stringBuilder = new StringBuilder(). //Design pattern :p
                     Append(playerHealthManager.GetCurrentHealth()).
                     Append("/").
                     Append(playerHealthManager.maxHealth);

        playerHealthText.text = stringBuilder.ToString();
    }
}
