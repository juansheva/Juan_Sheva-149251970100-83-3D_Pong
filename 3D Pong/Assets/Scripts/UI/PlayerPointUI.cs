using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPointUI : MonoBehaviour
{
    public GameplayUIManager gameplayUIManager;
    public Enum.Position position;
    public Text playerName;
    public Text playerScore;
    public PlayerController playerController;

    private void Start()
    {
        gameplayUIManager = FindObjectOfType<GameplayUIManager>();

        for (int i = 0; i < gameplayUIManager.gameplayManager.playerControllerList.Count; i++)
        {
            if (gameplayUIManager.gameplayManager.playerControllerList[i].position == position)
            {
                playerController = gameplayUIManager.gameplayManager.playerControllerList[i];
            }
        }
    }

    public void Update()
    {
        playerScore.text = playerController.point + "";
    }
}