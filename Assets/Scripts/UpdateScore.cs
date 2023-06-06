using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateScore : MonoBehaviour
{

    private Text textObject; // Corrected variable type

    void Start()
    {
        // Get the Text component from the game object
        textObject = GetComponent<Text>();

        // UnityEngine.Debug.Log("Initial textObject " + textObject.text);

        // Update the text value
        textObject.text = "0";

        // UnityEngine.Debug.Log("Updated textObject " + textObject.text);
    }

    public void UpdatePlayerScore(int score){
        textObject.text = score.ToString();
        // UnityEngine.Debug.Log("Player Scored! Score: " + score);
    }

    
}
