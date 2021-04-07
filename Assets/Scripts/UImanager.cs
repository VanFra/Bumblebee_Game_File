using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UImanager : MonoBehaviour
{
    private static int _score = 0;
    private static int _collect_count = 0;
    [SerializeField] private Text _scoreText;
    [SerializeField] private Text _message;
    


    private void Start()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Bumblebee_Game"))
        {
            _score = 0;
        }

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Endscreen"))
        {
            if (_collect_count == 3)
            {
                _score = _score * 2;
            }
        }
  
        _scoreText.text = "Score: " + _score;
        
    }

    public void AddScore(int score)
    {
        _score += score;
        _scoreText.text = "Score: " + _score;
    }

    public void AddCount(int count)
    {
        _collect_count += count;
    }

    public void ShowMessage()
    {
        _message.text = "You collected all pollen. Hurry and bring them home!";
    }

}
