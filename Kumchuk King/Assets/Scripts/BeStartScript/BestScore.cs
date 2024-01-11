using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BestScore : MonoBehaviour {

    public Text _bestScore;

    private int _finalScore;
    private static int _maxScore = 0;

    private void Awake()
    {
        _finalScore = PlayerPrefs.GetInt("LastScore");
        PlayerPrefs.Save();
        if (_maxScore < _finalScore)
        {
            _maxScore = _finalScore;
        }
    }

    // Use this for initialization
    void Start () {
        _bestScore.text = _maxScore.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
