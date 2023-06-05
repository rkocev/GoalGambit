using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class GoalLineController : MonoBehaviour
{
    private bool isFirstPlayerTurn = true;
    private int player1Score;
    private int player2Score;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("soccer_ball"))
        {
            if (isFirstPlayerTurn)
            {
                player1Score++;
                UnityEngine.Debug.Log("Player 1 Scored! Score: " + player1Score);
            }
            else
            {
                player2Score++;
                UnityEngine.Debug.Log("Player 2 Scored! Score: " + player2Score);
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
                UnityEngine.Debug.Log("Switching to " + (isFirstPlayerTurn ? "Player 1" : "Player 2") + "'s turn.");
            }
        }
    }

    private void EndGame()
    {
        int winner = player1Score > player2Score ? 1 : 2;
        UnityEngine.Debug.Log("Game Over! Player " + winner + " wins!");
        // TODO: we should display the winner or perform other end-game actions

    }
}
