using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalController : MonoBehaviour
{
    private GameplayManager gameplayManager;
    public Enum.Position position;
    public PlayerController playerController;

    private void Start()
    {
        gameplayManager = FindObjectOfType<GameplayManager>();
        for (int i = 0; i < gameplayManager.playerControllerList.Count; i++)
        {
            if (gameplayManager.playerControllerList[i].position == position)
            {
                playerController = gameplayManager.playerControllerList[i];
                playerController.goalController = this;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            if (!gameplayManager.gameIsFinish)
            {
                playerController.GetPoint(other.GetComponent<BallController>().score);
                gameplayManager.ballSpawner.RemoveBall(other.gameObject);
            }
        }
    }
}