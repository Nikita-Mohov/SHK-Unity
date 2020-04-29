using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]

public class PlayerBonusSystem : MonoBehaviour
{
    [SerializeField] private float _bonusDuration;

    private PlayerMovement _playerMovement;
    private List<Bonus> _currentBonuses;

    private void Start()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _currentBonuses = new List<Bonus>();
    }

    private void Update()
    {
        RefreshBonusList();
    }

    public void AddBonus()
    {
        _currentBonuses.Add(new Bonus(_bonusDuration));
        _playerMovement.ChangeSpeed(_currentBonuses.Count);
    }

    private void RemoveBonus(Bonus bonus)
    {
        _currentBonuses.Remove(bonus);
        _playerMovement.ChangeSpeed(_currentBonuses.Count);
    }

    private void RefreshBonusList()
    {
        for (int i = 0; i < _currentBonuses.Count; i++)
        {
            _currentBonuses[i].TimeLeft -= Time.deltaTime;
            if(_currentBonuses[i].TimeLeft <= 0)
            {
                RemoveBonus(_currentBonuses[i]);
            }
        }
    }
}
