using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayUIManager : MonoBehaviour
{
    public GameplayManager gameplayManager;

    public GameObject gameOverPanel;

    // Start is called before the first frame update
    private void Start()
    {
        gameplayManager = FindObjectOfType<GameplayManager>();
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public void GameOver(int _playerWinner)
    {
        GameObject panel = Instantiate(gameOverPanel, transform);
        panel.GetComponent<GameOverUI>().playerWinner.text = "Player " + _playerWinner + " Win";
    }
}