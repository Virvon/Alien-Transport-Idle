using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Transition : MonoBehaviour
{
    public State TargetState => _targetState;
    public bool NeedTransit { get; protected set; }

    [SerializeField] private State _targetState;

    protected Point Target { get; private set; }

    public void Init(Point target)
    {
        Target = target;
    }

    protected virtual void OnEnable()
    {
        NeedTransit = false;
    }
}
