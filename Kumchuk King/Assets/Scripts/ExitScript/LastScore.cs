using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LastScore : MonoBehaviour {

    public Text _lastScore;

    private int _formerlyScore;
    private int _firstScore = 0;
    private int _stepScore = 0;

    // Use this for initialization
    void Start () {
        FormerlyScore();
	}
	
	// Update is called once per frame
	void Update () {
        StartCoroutine(StepScore());
	}

    private void FormerlyScore()
    {
        _formerlyScore = PlayerPrefs.GetInt("LastScore");
        PlayerPrefs.Save();
    }

    IEnumerator StepScore()
    {
        if (_firstScore <= _formerlyScore)
        {
            _firstScore = _firstScore + (5 + _stepScore);
            _stepScore += 17;
            if (_firstScore > _formerlyScore)
            {
                _firstScore = _formerlyScore;
            }
            _lastScore.text = _firstScore.ToString();
        }
        else
        {
            yield break;
        }
    }
}
