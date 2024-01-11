using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

    [Header("Fruits")]
    public GameObject[] _fruits;

    private float _createTime = 0.7f; // 열매 스폰 딜레이

    private Transform[] _points; //자식들을 넣는 변수

    void Start()
    {
        _points = GameObject.FindGameObjectWithTag("SpawnPoint").GetComponentsInChildren<Transform>();

        if (_points.Length > 0)
        {
            StartCoroutine(CreateFruit());
        }
    }

    IEnumerator CreateFruit()
    {
        while (true)
        {
            if (GameManager.inGame)
            {
                int ranDom = Random.Range(1, 100);

                yield return new WaitForSeconds(_createTime);

                int idO = Random.Range(1, _points.Length);

                if (ranDom >= 1 && ranDom <= 68) // 기본
                {
                    Instantiate(_fruits[0], _points[idO].position, _points[idO].rotation);
                }
                if (ranDom > 68 && ranDom <= 80) // 금금
                {
                    Instantiate(_fruits[1], _points[idO].position, _points[idO].rotation);
                }
                if (ranDom > 80 && ranDom <= 85) // 마싯
                {
                    Instantiate(_fruits[2], _points[idO].position, _points[idO].rotation);
                }
                if (ranDom > 85 && ranDom <= 90) // 쿰척
                {
                    Instantiate(_fruits[3], _points[idO].position, _points[idO].rotation);
                }
                if (ranDom > 90 && ranDom <= 95) // 꼬르
                {
                    Instantiate(_fruits[4], _points[idO].position, _points[idO].rotation);
                }
                if (ranDom > 95 && ranDom <= 100) // 어크
                {
                    Instantiate(_fruits[5], _points[idO].position, _points[idO].rotation);
                }
            }
            yield return null;
        }
    }
}
