using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationView : MonoBehaviour
{
    public Station Station => _station;

    [SerializeField] private Station _station;
}
