using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerBonusSystem))]

public class PlayerCollision : MonoBehaviour
{
    private PlayerBonusSystem _bonusSystem;

    private void Start()
    {
        _bonusSystem = GetComponent<PlayerBonusSystem>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Enemy enemy))
        {
            if (other.TryGetComponent(out SpeedBonus speedBonus))
            {
                _bonusSystem.AddBonus();
            }

            enemy.Die();
        }
    }
}
