using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnder : MonoBehaviour
{
    [SerializeField] private GameObject _endPanel;
    [SerializeField] private EnemyCounter _enemyCounter;

    private void Start()
    {
        _endPanel.SetActive(false);
        _enemyCounter.EnemiesDestroyed += OnEnemysDestroyed;
    }

    public void OnEnemysDestroyed()
    {
        _endPanel.SetActive(true);
        Time.timeScale = 0f;
    }
}
