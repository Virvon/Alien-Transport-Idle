using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public bool IsBlocked { get; private set; }

    [SerializeField] private Menu _menu;

    private void OnEnable()
    {
        _menu.Clicked += ChangeLock;
    }

    private void OnDisable()
    {
        _menu.Clicked -= ChangeLock;
    }

    private void ChangeLock(bool isLock)
    {
        IsBlocked = isLock;
    }
}
