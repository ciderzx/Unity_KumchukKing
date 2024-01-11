using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour {

    // Use this for initialization
    void Start () {
       
    }
	
	// Update is called once per frame
	void Update () {
        if (HungerBar.instance._gameOver)
        {
            GameOver();
        }
        else
            return;
	}

    public void GameOver()
    {
        GameManager.inGame = false;
        Invoke("GameOverNextScene",2.1f);
    }

    private void GameOverNextScene()
    {
        SceneManager.LoadScene(5);
    }
}
