using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus 
{
    private float _timeLeft;

    public Bonus (float timeLeft)
    {
        _timeLeft = timeLeft;
    }

    public float TimeLeft { get => _timeLeft; set => _timeLeft = value; }
}
