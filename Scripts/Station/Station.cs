    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

[RequireComponent(typeof(StationCharacteristics))]
public class Station : MonoBehaviour, IPointerClickHandler
{
    public event UnityAction<int> PassengersCountChanged;
    public event UnityAction<StationCharacteristics> CharacteristicsChanged;
    public int PassengersCount => _passengersCount;

    [SerializeField] private Player _player;
    [SerializeField] private float _zoom = 10;
    [SerializeField] private GameObject _view;
    [SerializeField] private Menu _menu;
    [SerializeField] private CameraZoom _camera;

    private StationCharacteristics _stationCharacteristics;
    private int _passengersCount;
    private float _lastSpawnTime;

    public void OnPointerClick(PointerEventData eventData)
    {
        _menu.OpenPanel(_view);
        CharacteristicsChanged?.Invoke(_stationCharacteristics);
        _camera.ActiveZoom(gameObject.transform, _zoom);
    }

    private void Start()
    {
        _stationCharacteristics = GetComponent<StationCharacteristics>();
        _passengersCount = 0;
        _lastSpawnTime = 0;
    }

    private void Update()
    {
        float spawnTime = 60 / _stationCharacteristics.QuantityPerMinute;
        _lastSpawnTime += Time.deltaTime;

        if(_lastSpawnTime >= spawnTime)
        {
            if(_passengersCount < _stationCharacteristics.MaxPassengersCount)
            {
                _passengersCount++;
                PassengersCountChanged?.Invoke(_passengersCount);
            }

            _lastSpawnTime = 0;
        }
    }

    public void TakePassenger()
    {
        _passengersCount--;
        PassengersCountChanged?.Invoke(_passengersCount);
    }

    public void TryUpdateQuantityPerMinute()
    {
        bool isEnoughMoney = _player.TryTakeMoney(_stationCharacteristics.QuantityPerMinuteUpdateCost);

        if (isEnoughMoney)
        {
            _stationCharacteristics.UpdateQuantityPerMinute();
            CharacteristicsChanged?.Invoke(_stationCharacteristics);
        }
    }

    public void TryUpdateMaxPassengersCount()
    {
        bool isEnoughMoney = _player.TryTakeMoney(_stationCharacteristics.MaxPassengersCoutnUpdateCost);

        if (isEnoughMoney)
        {
            _stationCharacteristics.UpdateMaxPassengersCount();
            CharacteristicsChanged?.Invoke(_stationCharacteristics);
        }
    }
}
