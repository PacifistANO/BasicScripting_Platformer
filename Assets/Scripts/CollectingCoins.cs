using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectingCoins : MonoBehaviour
{
    [SerializeField] private Text _coinsView;

    private int _totalCoins;

    private void Start()
    {
        _coinsView.color = Color.yellow;
        _coinsView.text = _totalCoins.ToString();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent<CircleCollider2D>(out CircleCollider2D circleCollider2D))
        {
            collision.gameObject.SetActive(false);
            _totalCoins++;
            _coinsView.text = _totalCoins.ToString();
        }
    }
}
