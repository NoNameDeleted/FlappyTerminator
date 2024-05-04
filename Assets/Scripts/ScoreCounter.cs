using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    private int _score = 0;

    public event Action<int> ScoreChanged;

    public void Reset()
    {
        _score = 0;
        ScoreChanged?.Invoke(_score);
    }

    public void Add(int points = 1)
    {
        if (points > 0)
        {
            _score += points;
        }

        ScoreChanged?.Invoke(_score);
    }
}
