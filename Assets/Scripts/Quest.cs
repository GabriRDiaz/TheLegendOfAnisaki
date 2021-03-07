using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{
    public int questID;
    public bool isCompleted;
    private QuestManager questManager;
    public string title;
    public string questText;
    public string completedText;
    public Sprite img;

    public void StartQuest(){
        questManager = FindObjectOfType<QuestManager>();
        questManager.QuestText(title+":\n"+questText);
    }

    public void CompleteQuest(){
        questManager = FindObjectOfType<QuestManager>();
        if(img!=null){
            Debug.Log("Img");
            questManager.QuestText(title+":\n"+completedText,img);
        }else{
            questManager.QuestText(title+":\n"+completedText);
        }
        isCompleted = true;
        gameObject.SetActive(false);
    }
}
