using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UImanager : MonoBehaviour
{
    private int _score = 0;
    [SerializeField] private Text _scoreText;
    [SerializeField] private Text _message;

    private void Start()
    {
        _scoreText.text = "Score: " + _score;
        
    }

    public void AddScore(int score)
    {
        _score += score;
        _scoreText.text = "Score: " + _score;

    }

    public void ShowMessage()
    {
        _message.text = "You collected all pollen. Hurry and bring them home!";
    }

}
