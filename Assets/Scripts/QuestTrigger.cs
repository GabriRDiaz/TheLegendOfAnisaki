using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestTrigger : MonoBehaviour
{
QuestManager questManager;
    public int questID;
    public bool isStartPoint, isEndPoint;
    private bool playerInZone;
    public bool autoAccept;
    
    void Start()
    {
        questManager = FindObjectOfType<QuestManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name.Equals("Player")){
            playerInZone = true;
        }
    }

    void OnTriggerExit2D(Collider2D other){
    if(other.gameObject.name.Equals("Player")){
        playerInZone = false; 
        
    }
    }
    void Update(){
        if(playerInZone){
            if(autoAccept || (!autoAccept&&Input.GetMouseButtonDown(1))){
                Quest q = questManager.GetQuest(questID);
                if(q==null){Debug.LogErrorFormat("La misión con id {0} no existe", questID); return;}
                if(!q.isCompleted){ //Eliminando este if la misión puede ser repetible. De implementarse podría usar overload en un método.
                    if(isStartPoint){
                        if(!q.gameObject.activeInHierarchy){
                            q.gameObject.SetActive(true);
                            q.StartQuest();
                        }
                    }
                    if(isEndPoint){
                        if(q.gameObject.activeInHierarchy){
                            q.CompleteQuest();
                        }
                    }
                }
            }
        }
    }
}
