using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour{

    private float _topPoint = -2.7f;
    private float _botPoint = -3.6f;

    public float _downSpeed;

    private float _stopPointB = -4.6f;

    public GameObject _bottomPoint;

    public void Down()
    {
        float down = _downSpeed * Time.deltaTime;
        Vector3 fruitPo = new Vector3(0, down);

        if (_bottomPoint.transform.position.y > _stopPointB)
        {
            transform.position -= fruitPo;
        }
        else
        {
            Destroy(gameObject, 0.12f);
            return;
        }
    }

    void OnTriggerEnter2D(Collider2D player)
    {
        if (player.transform.CompareTag("Player"))
        {
            if (_bottomPoint.transform.position.y < _topPoint && _bottomPoint.transform.position.y > _botPoint)
            {
                Destroy(this.gameObject);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        Down();
    }
}

