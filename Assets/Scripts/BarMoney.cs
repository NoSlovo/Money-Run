using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;

public class BarMoney : MonoBehaviour
{
    [SerializeField] private Text _textUI;
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _player.ChengMoney += Visualize;
    }

    private void Awake()
    {
        _textUI = GetComponent<Text>();
    }

    private void Visualize()
    {
        if (_player.Money >= 0)
        {
            _textUI.text = Convert.ToString(_player.Money);
        }
    }

    private void OnDisable()
    {
        _player.ChengMoney -= Visualize;
    }
}
