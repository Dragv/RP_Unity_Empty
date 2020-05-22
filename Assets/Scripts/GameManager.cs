using System;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    #region Singleton
    public static GameManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }
    #endregion

    public GameObject[] _lives;
    public Birdo _birdo;

    public bool _paused;

    public Slider _slider;
    public Image _fillArea;

    private void Start()
    {
        for (int i = 0; i < _lives.Length; i++)
        {
            _lives[i].SetActive(true);
        }
    }

    private void Update()
    {
        _slider.value = _birdo._currentCooldown;

        if (_slider.value >= 3)
        {
            _fillArea.color = Color.green;
        }
        else
        {
            _fillArea.color = Color.white;
        }

        switch (_birdo._lives)
        {
            case 2:
                _lives[2].SetActive(false);
                break;
            case 1:
                _lives[1].SetActive(false);
                break;
            case 0:
                _lives[2].SetActive(false);
                _lives[1].SetActive(false);
                _lives[0].SetActive(false);
                GameOver();
                break;
            default:

                break;
        }
    }

    public void ClearScreen()
    {

    }

    private void GameOver()
    {
        
    }
}
