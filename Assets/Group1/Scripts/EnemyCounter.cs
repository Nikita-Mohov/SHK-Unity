using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyCounter : MonoBehaviour
{
    private List<Enemy> _enemies;

    public event UnityAction EnemiesDestroyed;

    private void Start()
    {
        _enemies = new List<Enemy>();
        FindEnemies();
    }

    private void FindEnemies()
    {
        Enemy[] enemies = GameObject.FindObjectsOfType<Enemy>();
        for (int i = 0; i < enemies.Length; i++)
        {
            _enemies.Add(enemies[i]);
            enemies[i].Died += OnEnemyDied;
        }
    }

    public void OnEnemyDied(Enemy enemy)
    {
        _enemies.Remove(enemy);
        if (_enemies.Count == 0)
        {
            EnemiesDestroyed?.Invoke();
        }
    }
}
