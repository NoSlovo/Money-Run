using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;

[RequireComponent(typeof(Text))]

public class PriceBarCard : MonoBehaviour
{
    [SerializeField] private Card _card;
    [SerializeField] private Player _player;
    [SerializeField] private Text _text;

    private void OnEnable()
    {
        _player.ChengMoney += Change—olor;
    }

    private void Awake()
    {
        _text = GetComponent<Text>();
        _text.text = _card.PriceCard.ToString();
    }

    private void Change—olor()
    {
        Color color;

        if (_player.Money >= _card.PriceCard)
        {
            color = Color.green;
            _text.color = color;
        }
        else
        {
            color = Color.red;
            _text.color = color;
        }
    }

    public void OffBardMoney()
    {
        enabled = false;
        _text.enabled = false;
    }

    private void OnDisable()
    {
        _player.ChengMoney -= Change—olor;
    }

}  
