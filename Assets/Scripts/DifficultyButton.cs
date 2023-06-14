using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    public Button button;
    public GameManager gameManagerScript;

    // Start is called before the first frame update
    void Start()
    {
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
        button = GetComponent<Button>();
        button.onClick.AddListener(SetDifficulty);
    }
    void SetDifficulty()
    {
        if(gameObject.name == "EasyButton")
        {
            gameManagerScript.StartGame(10);
        } else if(gameObject.name == "MediumButton")
        {
            gameManagerScript.StartGame(14);
        }
        else if (gameObject.name == "HardButton")
        {
            gameManagerScript.StartGame(16);
        }

        Debug.Log(gameObject.name + " was clicked");
    }
}
