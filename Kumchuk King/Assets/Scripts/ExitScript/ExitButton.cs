﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitButton : MonoBehaviour {

    public void NextButton()
    {
        SceneManager.LoadScene(1);
    }
}
