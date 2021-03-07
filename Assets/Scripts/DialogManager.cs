using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public GameObject dialBox;
    public Text dialText;
    public Image dialAvatar;
    public bool isActive;

    public string[] dialLines;
    public int currentLine;

    private PlayerController playerController;

    void Start()
    {
        isActive = false;
        dialBox.SetActive(false);
        playerController = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
    if (isActive && Input.GetKeyDown(KeyCode.Space))
        {
            currentLine++;
            
            if (currentLine >= dialLines.Length)
            {
                playerController.isTalking = false;
                currentLine = 0;
                isActive = false;
                dialAvatar.enabled = false;
                dialBox.SetActive(false);
            }
            else
            {
                dialText.text = dialLines[currentLine];
            }
        }
    }
    public void ShowDialog(string[] lines){
        currentLine = 0;
        dialLines = lines;
        isActive = true;
        dialBox.SetActive(true);
        dialText.text = dialLines[currentLine]; //Mostrar primera linea
        playerController.isTalking = true;
    }

    public void ShowDialog(string[] lines, Sprite sprite){
        ShowDialog(lines);
        dialAvatar.enabled = true;
        dialAvatar.sprite = sprite;
    }
}
