using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HungerBar : MonoBehaviour {

    public static HungerBar instance;

    public enum FruitType
    {
        gibon = 2,
        gumgum = 2,
        kumchuk = 3,
        masit = 7,
        aku = -6,
        ggoRrrrrr = -12
    }

    public Image _mask;

    private RectTransform _maskRect;

    public float _maxHP;
    public bool _gameOver = false;

    [SerializeField]private float _currentHP;
    private float _maxHpBarWidth;
    private float _downSpeed = 1.0f;
    private float _healthSpeed = 0.005f;

    void Awake()
    {
        if (instance)
        {
            Debug.Log("다중 인스턴스 감시 : 주의 바람");
        }
        else
        {
            instance = this;
        }

    }

    void Start()
    {
        _maskRect = _mask.GetComponent<RectTransform>();
        _maxHpBarWidth = _maskRect.sizeDelta.x;
        _currentHP = _maxHP;
    }

    void Update()
    {
        HpDown();
    }

    public void HpUp(FruitType type)
    {
        if (_currentHP >= _maxHP)
        {
            _currentHP = _maxHP;
        }
        if (_currentHP < _maxHP)
        {
            _currentHP += (float)type;
        }
    }

    public void Sobooni(float speed)
    {
        _healthSpeed -= speed;
    }

    private void HpDown()
    {
        _downSpeed += _healthSpeed;

        _currentHP -= _downSpeed * Time.deltaTime;

        if (_currentHP < 0)
        {
            _currentHP = 0;
            if (_currentHP == 0)
            {
                _gameOver = true;
            }
        }

        float deltaSize = _currentHP / _maxHP;

        _maskRect.sizeDelta = new Vector2(_maxHpBarWidth * deltaSize, _maskRect.sizeDelta.y);
    }
}
