using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _startingSpeed;

    private float _speed;

    private void Start()
    {
        _speed = _startingSpeed;
    }

    private void Update()
    {
        transform.Translate(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * _speed * Time.deltaTime);
    }

    public void ChangeSpeed(int degree)
    {
        float multiplier = Mathf.Pow(2, degree);
        _speed = _startingSpeed * multiplier;
    }
}
