using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class TeleportMenu : MonoBehaviour
{
    [SerializeField] private Teleport _teleport;
    [SerializeField] private Robot _robot;
    [Header("Μενώ")]
    [SerializeField] private CanvasGroup _menuCanvasGroup;
    [SerializeField] private Image _darkScreen;
    [SerializeField] private float _time;
    [SerializeField] private List<Button> _teleportButtons = new List<Button>();

    private void OnEnable()
    {
        _robot.Died += ShowMenu;

        for (int i = 0; i < _teleportButtons.Count; i++)
        {
            int buttonIndex = i; 
            _teleportButtons[i].onClick.AddListener(() => OnButtonClick(buttonIndex));
        }
    }
    
    private void OnDisable()
    {
        _robot.Died -= ShowMenu;

        for (int i = 0; i < _teleportButtons.Count; i++)
        {
            int buttonIndex = i; 
            _teleportButtons[i].onClick.RemoveListener(() => OnButtonClick(buttonIndex));
        }
    }

    private void OnButtonClick(int buttonIndex)
    {
        _teleport.TeleportToPoint(buttonIndex);
        CloseMenu();
    }

    public void ShowMenu()
    {
        _menuCanvasGroup.DOFade(1, _time);
    }

    private void CloseMenu()
    {
        _menuCanvasGroup.DOFade(0, _time);
    }
}
