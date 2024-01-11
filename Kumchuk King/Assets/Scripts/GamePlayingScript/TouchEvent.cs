using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchEvent : MonoBehaviour {

    private PlayerMove _playerScript;

    private Vector2 _point;

    void Start()
    {
        _playerScript = GameObject.FindObjectOfType<PlayerMove>();
    }

    private void Update()
    {
#if UNITY_ANDROID
        TouchPoint();
#endif
    }

    public void TouchPoint()
    {
#if UNITY_EDITOR
        Debug.Log("EDITOR MODE");
#elif UNITY_ANDROID
        Vector2 TouchPoint = Input.GetTouch(0).position;

        _point = Camera.main.ScreenToViewportPoint(TouchPoint);

        if (Input.GetTouch(0).phase == TouchPhase.Stationary)
        {
            if (_point.x < 0.5f)
            {
                _playerScript.type = 1;
            }
            if (_point.x > 0.5f)
            {
                _playerScript.type = -1;
            }
        }
        else if (Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            _playerScript.type = 0;
        }
#endif
    }
}