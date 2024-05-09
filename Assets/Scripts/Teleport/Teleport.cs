using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Teleport : MonoBehaviour
{
    [SerializeField] private Transform _objectTransform;
    [SerializeField] private TeleportPointsContainer _teleportPointsContainer;
    [SerializeField] private Button _teleportButton;

    private void OnEnable()
    {
        _teleportButton.onClick.AddListener(OnTPButtonClick);
    }
    
    private void OnDisable()
    {
        _teleportButton.onClick.RemoveListener(OnTPButtonClick);
    }

    private void OnTPButtonClick()
    {
        TeleportPoint teleportPoint = _teleportPointsContainer.GetTeleportPoint();

    }
}
