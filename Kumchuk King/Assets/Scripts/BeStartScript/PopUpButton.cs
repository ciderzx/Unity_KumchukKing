using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpButton : MonoBehaviour {

    public GameObject _MadePP;

    public void MadePeopleButtonOn()
    {
        _MadePP.SetActive(true);
    }

    public void MadePeopleButtonOff()
    {
        _MadePP.SetActive(false);
    }
}
