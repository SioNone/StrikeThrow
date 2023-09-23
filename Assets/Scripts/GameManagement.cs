using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagement : MonoBehaviour
{
    public GameObject playerOne, playerTwo;
    public float moveSpeed = 3f;
    public int playerOneScore, playerTwoScore;
    public int playerOneState, playerTwoState;

    void Start()
    {
        playerOneScore = 0;
        playerTwoScore = 0;
    }

    void Update()
    {
        Player playerOneScript = playerOne.GetComponent<Player>();
        Player playerTwoScript = playerTwo.GetComponent<Player>();

        playerOneState = playerOneScript.playerState;
        playerTwoState = playerTwoScript.playerState;

        float step = moveSpeed * Time.deltaTime;

        // There's probably a better way of doing this part below (maybe? Idk)

        // If a player exits neutral
        if (playerOneState != 0 || playerTwoState != 0)
        {
            // Checks all instances where player 1 can begin and win an interaction
            if ((playerOneState == 1 && (playerTwoState != 3 || playerTwoState == 0)) || (playerOneState == 2 && (playerTwoState == 3 || playerTwoState == 0)))
            {
                Debug.Log("Player 1 Pushes");

                // Move Players | Players Move Right
                playerOne.transform.position += new Vector3(1, 0, 0);
                playerTwo.transform.position += new Vector3(1, 0, 0);

                // Update Scores
                playerOneScore += 1;
                playerTwoScore -= 1;
            }

            // Checks all instances where player 2 can begin and win an interaction
            if ((playerTwoState == 1 && (playerOneState != 3 || playerOneState == 0)) || (playerTwoState == 2 && (playerOneState == 3 || playerOneState == 0)))
            {
                Debug.Log("Player 2 Pushes");

                // Move Players | Players Move Left
                playerOne.transform.position -= new Vector3(1, 0, 0);
                playerTwo.transform.position -= new Vector3(1, 0, 0);

                // Update Scores
                playerTwoScore += 1;
                playerOneScore -= 1;
            }

            // Checks all instances where a clash occurs
            if (playerOneState == playerTwoState)
            {
                Debug.Log("Clash");
            }

            // Reset Players to neutral
            // playerOneScript.playerState = 0;
            // playerTwoScript.playerState = 0;
        }

        if (playerOneScore == 5 || playerTwoScore == 5)
        {
            if (playerOneScore > playerTwoScore)
            {
                Debug.Log("Player 1 Win");
            } 
            else
            {
                Debug.Log("Player 2 Win");
            }
        }
    }
}
