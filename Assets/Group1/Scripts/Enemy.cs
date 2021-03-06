﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Vector3 _target;

    public event UnityAction<Enemy> Died;

    private void Start()
    {
        ApplyNewTarget();
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target, _speed * Time.deltaTime);
        if(transform.position == _target)
        {
            ApplyNewTarget();
        }
    }

    private void ApplyNewTarget()
    {
        _target = Random.insideUnitCircle * 4;
    }

    public void Die()
    {
        Died?.Invoke(this);
        Destroy(gameObject);
    }
}
