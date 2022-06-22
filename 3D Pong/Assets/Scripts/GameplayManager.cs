using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    public GameplayUIManager gameplayUIManager;
    public BallSpawner ballSpawner;
    public List<PlayerController> playerControllerList;

    public bool gameIsFinish;
    public int playerLose;

    // Start is called before the first frame update
    private void Awake()
    {
        Time.timeScale = 1;
        gameplayUIManager = FindObjectOfType<GameplayUIManager>();
        ballSpawner = FindObjectOfType<BallSpawner>();
        PlayerController[] playerControllerTemp = FindObjectsOfType<PlayerController>();
        foreach (PlayerController playerController in playerControllerTemp)
        {
            playerControllerList.Add(playerController);
        }
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public void CheckWin()
    {
        if (playerLose >= 3)
        {
            Time.timeScale = 0;
            gameIsFinish = true;
            int playerWinner;
            for (int i = 0; i < playerControllerList.Count; i++)
            {
                if (playerControllerList[i].isLose == false)
                {
                    playerWinner = playerControllerList[i].playerNumber;
                    gameplayUIManager.GameOver(playerWinner);
                }
            }
        }
    }
}