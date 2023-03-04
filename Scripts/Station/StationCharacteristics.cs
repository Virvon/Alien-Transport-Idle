using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationCharacteristics : MonoBehaviour
{
    public float QuantityPerMinute => _quantityPerMinute;
    public int MaxPassengersCount => _maxPassengersCount;
    public int QuantityPerMinuteUpdateCost => _quantityPerMinuteUpdateCost;
    public int MaxPassengersCoutnUpdateCost => _maxPassengersCountUpdateCost;

    public int QuantityPerMinuteUpdateLevel => _quantityPerMinuteUpdateLevel;
    public int MaxPassengersCountUpdateLevel => _maxPassengersCountUpdateLevel;

    [SerializeField] private float _quantityPerMinute;
    [SerializeField] private int _maxPassengersCount;
    [SerializeField] private int _quantityPerMinuteUpdateCost;
    [SerializeField] private int _maxPassengersCountUpdateCost;

    private int _quantityPerMinuteUpdateLevel = 1;
    private int _maxPassengersCountUpdateLevel = 1;

    public void UpdateMaxPassengersCount()
    {
        _maxPassengersCount += 2;
        _maxPassengersCountUpdateLevel++;
        _maxPassengersCountUpdateCost += 2;
    }

    public void UpdateQuantityPerMinute()
    {
        _quantityPerMinute += 2.4f;
        _quantityPerMinuteUpdateLevel++;
        _quantityPerMinuteUpdateCost += 3;
    }
}
