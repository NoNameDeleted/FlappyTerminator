using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ShipMover), typeof(ScoreCounter), typeof(ShipCollisionHandler))]
[RequireComponent (typeof(Shooter))] 
public class Ship : MonoBehaviour
{
    private ShipMover _shipMover;
    private ScoreCounter _scoreCounter;
    private ShipCollisionHandler _handler;
    private Shooter _shooter;

    private readonly string Fire1 = nameof(Fire1);

    public event Action GameOver;

    private void Awake()
    {
        _shipMover = GetComponent<ShipMover>();
        _scoreCounter = GetComponent<ScoreCounter>();
        _handler = GetComponent<ShipCollisionHandler>();
        _shooter = GetComponent<Shooter>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _shooter.Shoot();
        }
    }

    public void Reset()
    {
        _scoreCounter.Reset();
        _shipMover.Reset();
    }

    public void Destroy()
    {
        GameOver?.Invoke();
    }
}