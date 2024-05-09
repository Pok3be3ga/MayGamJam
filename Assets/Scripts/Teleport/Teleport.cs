using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Teleport : MonoBehaviour
{
    [SerializeField] private Robot _robot;
    [SerializeField] private List<Transform> _teleportPoints;

    public void TeleportToPoint(int buttonIndex)
    {
        Debug.Log(buttonIndex);
        _robot.SetPosition(new(_teleportPoints[buttonIndex].position.x, _teleportPoints[buttonIndex].position.y));
    }
}
