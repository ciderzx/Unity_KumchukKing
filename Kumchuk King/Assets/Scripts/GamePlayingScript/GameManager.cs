using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    [Header("Delay")]
    public GameObject _ReadyImage;
    public GameObject _StartImage;

    [Header("Audio")]
    public AudioClip _audioClip;
    public AudioSource _audioSource;

    private int _temptime = 0;

    public static bool inGame;

    private void Awake()
    {
        _audioSource.clip = _audioClip;
        inGame = false;
    }
    private void Start()
    {
        _temptime = System.DateTime.Now.Second;
        Time.timeScale = 0;
    }

    void Update()
    {
        GameDelay();
    }

    public void GameDelay()
    {
        switch (System.DateTime.Now.Second - _temptime)
        {
            case 1:
                _ReadyImage.SetActive(true);
                break;
            case 2:
                _ReadyImage.SetActive(true);
                break;
            case 3:
                Time.timeScale = 1;
                inGame = true;
                _audioSource.Play();
                _ReadyImage.SetActive(false);
                _StartImage.SetActive(true);
                break;
            case 4:
                _StartImage.SetActive(false);
                break;
        }
    }
}
