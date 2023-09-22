using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject enemy;

    // 0 = Neutral, 1 = Strike, 2 = Throw, 3 = Block
    public int playerState = 0;

    // Controls
    public string strikeButton, throwButton, blockButton;

    [Header("Action Properties")]
    // Time until actions become active
    public float strikeStartup, throwStartup, blockStartup;

    // How long actions are active for
    public float strikeActive, throwActive, blockActive;

    // Time for actions to recover
    public float strikeRecovery, throwRecovery, blockRecovery;

    // Update is called once per frame
    void Update()
    {
        // Strike
        if (Input.GetKeyDown(strikeButton))
        {
            playerState = 1;
        }

        // Throw
        if (Input.GetKeyDown(throwButton))
        {
            playerState = 2;
        }

        // Block
        if (Input.GetKeyDown(blockButton))
        {
            playerState = 3;
        }
    }
}
