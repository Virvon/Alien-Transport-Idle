using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public event UnityAction<int> MoneyCountChanged;
    public event UnityAction MoneySpent;
    public int Money => _money;

    [SerializeField] private int _money;

    private void Start()
    {
        MoneyCountChanged?.Invoke(_money);
    }

    public void GiveMoney(int money)
    {
        _money += money;
        MoneyCountChanged?.Invoke(_money);
    }

    public bool TryTakeMoney(int money)
    {
        if(_money < money)
            return false;

        _money -= money;
        MoneySpent?.Invoke();
        MoneyCountChanged?.Invoke(_money);
        return true;
    }
}
