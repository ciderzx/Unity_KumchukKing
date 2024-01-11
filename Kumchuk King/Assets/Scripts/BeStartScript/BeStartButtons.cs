using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeStartButtons : MonoBehaviour {

    public void PlayButton()
    {
        SceneManager.LoadScene(2);
    }

    public void CharShopButton()
    {
        SceneManager.LoadScene(3);
    }

    public void ItemShopButton()
    {
        SceneManager.LoadScene(4);
    }

}
