using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyCounter : MonoBehaviour
{
    private List<Enemy> _enemies;

    public UnityAction EnemiesDestroyed;

    private void Start()
    {
        _enemies = new List<Enemy>();
        FindEnemys();
    }

    private void FindEnemys()
    {
        Enemy[] enemies = GameObject.FindObjectsOfType<Enemy>();
        for (int i = 0; i < enemies.Length; i++)
        {
            _enemies.Add(enemies[i]);
            enemies[i].Died += OnEnemyDied;
        }
    }

    private void CheckList()
    {
        if(_enemies.Count == 0)
        {
            EnemiesDestroyed?.Invoke();
        }
    }

    public void OnEnemyDied(Enemy enemy)
    {
        _enemies.Remove(enemy);
        CheckList();
    }
}
