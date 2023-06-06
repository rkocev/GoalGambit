using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class GoalLineController : MonoBehaviour
{
    private bool isFirstPlayerTurn = true;
    private int player1Score;
    private int player2Score;

    GameObject textPlayer1;
    GameObject textPlayer2;

    UpdateScore updateTextPlayer1;
    UpdateScore updateTextPlayer2;

    private Text player1Turn;
    private Text player2Turn;

    private Text winnerText;
    
    // public Ball ball;
    // Start is called before the first frame update
    void Start()
    {

        // Get the UpdateText script component from the found game object
        updateTextPlayer1 = GameObject.Find("Player1-Score").GetComponent<UpdateScore>();
        updateTextPlayer2 = GameObject.Find("Player2-Score").GetComponent<UpdateScore>();


        player1Turn = GameObject.Find("Player1").GetComponent<Text>();
        player2Turn = GameObject.Find("Player2").GetComponent<Text>();
        player1Turn.text = "Player 1";
        player2Turn.text = "";

        winnerText = GameObject.Find("Winner").GetComponent<Text>();
        winnerText.text = "";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Icosphere")
        {
            if (isFirstPlayerTurn)
            {
                player1Score++;
                UnityEngine.Debug.Log("Player 1 Scored! Score: " + player1Score);
                updateTextPlayer1.UpdatePlayerScore(player1Score);

            }
            else
            {
                player2Score++;
                UnityEngine.Debug.Log("Player 2 Scored! Score: " + player2Score);
                updateTextPlayer2.UpdatePlayerScore(player2Score);
            }

            if (player1Score >= 5 && player2Score >= 5)
            {
                if (player1Score != player2Score)
                {
                    EndGame();
                }
                else
                {
                    UnityEngine.Debug.Log("It's a draw! Both players will have one more shot.");
                }
            }
            else if (isFirstPlayerTurn && player1Score >= 5)
            {
                UnityEngine.Debug.Log("Player 1 wins with a score of " + player1Score);
                EndGame();
            }
            else if (!isFirstPlayerTurn && player2Score >= 5)
            {
                UnityEngine.Debug.Log("Player 2 wins with a score of " + player2Score);
                EndGame();
            }
            else
            {
                isFirstPlayerTurn = !isFirstPlayerTurn;
                // Wait for 1 second then reset the ball
                // StartCoroutine(WaitForBallReset());
                
                

                player1Turn.text = isFirstPlayerTurn ? "Player 1" : "";
                player2Turn.text = isFirstPlayerTurn ? "" : "Player 2";
                UnityEngine.Debug.Log("Switching to " + (isFirstPlayerTurn ? "Player 1" : "Player 2") + "'s turn.");
            }
        }
    }

    private void EndGame()
    {
        int winner = player1Score > player2Score ? 1 : 2;
        UnityEngine.Debug.Log("Game Over! Player " + winner + " wins!");

        player1Turn.text = "";
        player2Turn.text = "";

        winnerText.text = "Winner is\n" + (winner == 1 ? "Player 1" : "Player 2") + "!";
        // TODO: we should display the winner or perform other end-game actions

    }
}
