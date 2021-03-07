using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public List<Quest> quests;
    private DialogManager dialogManager;
    
    void Start()
    {
        dialogManager = FindObjectOfType<DialogManager>();
        foreach(Transform t in transform){ //Recorre todos los hijos
            quests.Add(t.gameObject.GetComponent<Quest>());
        }
    }

    public void QuestText(string txt){
        dialogManager.ShowDialog(new string[] {txt});
    }
    public void QuestText(string txt, Sprite img){
        dialogManager.ShowDialog(new string[] {txt},img);
    }
    public Quest GetQuest(int questID){
        Quest q = null;
        foreach(Quest i in quests){
            if(i.questID == questID){
                q = i;
            }
        } return q;
    }
}
