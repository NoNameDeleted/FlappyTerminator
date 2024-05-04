using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Ship _ship;
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private EnemyBulletsSpawner _enemyBulletsSpawner;
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private EndGameScreen _endGameScreen;
    [SerializeField] private ScoreCounter _scoreCounter;

    private void OnEnable()
    {
        _startScreen.PlayButtonClicked += OnPlayButtonClick;
        _endGameScreen.RestartButtonClicked += OnRestartButtonClick;
        _ship.GameOver += OnGameOver;
    }

    private void OnDisable()
    {
        _startScreen.PlayButtonClicked -= OnPlayButtonClick;
        _endGameScreen.RestartButtonClicked -= OnRestartButtonClick;
        _ship.GameOver -= OnGameOver;
    }

    private void Start()
    {
        Time.timeScale = 0;
        _startScreen.Open();
    }

    private void OnGameOver()
    {
        Time.timeScale = 0;
        _endGameScreen.Open();
    }

    private void OnRestartButtonClick()
    {
        _endGameScreen.Close();
        StartGame();
    }

    public void OnPlayButtonClick()
    {
        _startScreen.Close();
        _endGameScreen.BlockRaycast();
        StartGame();
    }

    private void StartGame()
    {
        _enemySpawner.Reset();
        _enemyBulletsSpawner.Reset();
        _scoreCounter.Reset();
        Time.timeScale = 1;
        _ship.Reset();
    }
}
