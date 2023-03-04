using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipCharacteristics : MonoBehaviour
{
    public int MaxPassengersCount => _maxPassengersCount;
    public int CapacityUpdateCost => _capacityUpdateCost;
    public int SpeedUpdateCost => _speedUpdateCost;
    public float Speed => _speed;
    public int Fare => _fare;
    public int CapacityUpdateLevel => _capacityUpdateLevel;
    public int SpeedUpdateLevel => _speedUpdateLevel;

    [SerializeField] private int _maxPassengersCount;
    [SerializeField] private int _capacityUpdateCost;
    [SerializeField] private int _fare;
    [SerializeField] private int _speedUpdateCost;
    [SerializeField] private float _speed;

    private int _capacityUpdateLevel = 1;
    private int _speedUpdateLevel = 1;

    public void UpdateSpeed()
    {
        _speed += 0.4f;
        _speedUpdateCost += 5;
        _speedUpdateLevel++;
    }

    public void UpdateCapacity()
    {
        _capacityUpdateCost += 8;
        _fare++;
        _maxPassengersCount++;
        _capacityUpdateLevel++;
    }
}
