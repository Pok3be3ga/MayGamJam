using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPointsContainer : MonoBehaviour
{
    [SerializeField] private List<TeleportPoint> _teleportPoints;

    private int _currentTeleportIndex = 0;

    public TeleportPoint GetTeleportPoint()
    {
        if (_teleportPoints[++_currentTeleportIndex] != null)
            return _teleportPoints[_currentTeleportIndex];
        else
            return null;
    }
}
