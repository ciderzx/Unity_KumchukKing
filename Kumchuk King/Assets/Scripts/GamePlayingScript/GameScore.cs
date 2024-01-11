using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScore : MonoBehaviour {

    public enum FruitScore
    {
        gibon = 5000,
        gumgum = 0,
        kumchuk = 10000,
        masit = 10000,
        aku = 2500,
        ggoRrrrrr = 2500
    }

    public Text _score;

    private bool _characterType;

    private int _healthScore = 0;
    private float _sumNumber = 0;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        _score.text = _healthScore.ToString();
    }

    public bool YoutooberCharecter
    {
        set
        {
            _characterType = value;
        }
    }

    public void fruitScore(FruitScore score)
    {
        if (_characterType == true) //유투버 캐릭터라면
        {
            _sumNumber += ((float)score * 1.2f);
        }
        else //다른 캐릭터들 이라면
        {
            _sumNumber += (float)score;
        }
        _healthScore = (int)_sumNumber;
        PlayerPrefs.SetInt("LastScore", _healthScore);
        PlayerPrefs.Save();
    }
}
