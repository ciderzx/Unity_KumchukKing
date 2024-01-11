using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityScript;

public class PlayerMove : MonoBehaviour {

    [Header("Eat Audio")]
    public AudioClip _audioClip;
    public AudioSource _audioSource;

    private HungerBar _hungerScript;
    private GameScore _scoreScript;

    private float _moveSpeed = 3.3f;

    [Header("StopPoint")]
    public float _stopPointR;
    public float _stopPointL;

    public GameObject leftPoint = null;

    private float _moveStop = 0f;
    private float _moveHurry = 10f;
    private float _stopTime = 0.8f;

    private IEnumerator _eat;

    private bool _eatingType;
    private bool _direction;
    private int _type;

    private Animator _anim;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
    }

    void Start()
    {
        _audioSource.clip = _audioClip;
        _hungerScript = GameObject.FindObjectOfType<HungerBar>();
        _scoreScript = GameObject.FindObjectOfType<GameScore>();
    }

    // Update is called once per frame
    void Update () {
        if (GameManager.inGame)
        {
            Move();
        }
        if (HungerBar.instance._gameOver)
        {
            _anim.SetBool("GameOver", true);
        }
        else
            return;
    }

    public int type // touch
    {
        set
        {
            _type = value;
        }
    }

    void Move()
    {
        Vector3 scale = transform.localScale;

        float horizonPoint = Input.GetAxisRaw("Horizontal");
        float leftPoinrX = leftPoint.transform.position.x;

        float moveDis = _moveSpeed * Time.deltaTime; //이동을 하게 하는 속력같은것
        Vector2 move = new Vector2(moveDis, 0); // 벡터2의 좌표값에 내가 가고싶은 값을 넣어줌

#if UNITY_EDITOR
        //캐릭터 뒤집기
        _direction = (horizonPoint < 0);
        if (horizonPoint == 0)
        {
            _anim.SetBool("Move", false);
            return;
        }

        if (_direction) //멀쩡할때
        {
            scale.x = 1;
            _anim.SetBool("Move", true);
            if (horizonPoint < 0 && leftPoinrX > _stopPointL) // 왼쪽을 눌렀는가
            {
                transform.position -= (Vector3)move; // 위 조건식이 맞다면 왼쪽으로 이동한다 / 포지션에 벡터2를 3로 변환해준뒤 x와 y의 좌표를 넣는다
            }
        }
        if (!_direction) // 뒤집혔을때
        {
            scale.x = -1;
            _anim.SetBool("Move", true);
            if (horizonPoint > 0 && leftPoinrX < _stopPointR) //오른쪽을 눌렀는가
            {
                transform.position += (Vector3)move; // 위 조건식이 맞다면 오른쪽으로 이동한다 / 포지션에 벡터2를 3로 변환해준뒤 x와 y의 좌표를 넣는다
            }
        }
        transform.localScale = scale;
#elif UNITY_ANDROID
        if (_type == 1) //멀쩡할때
        {
            scale.x = 1;
            if (_type == 1 && leftPoinrX > _stopPointL) // 왼쪽을 눌렀는가
            {
                transform.position -= (Vector3)move; 
            }
            _anim.SetBool("Move", true);
        }
        if (_type == -1) // 뒤집혔을때
        {
            scale.x = -1;
            if (_type == -1 && leftPoinrX < _stopPointR) //오른쪽을 눌렀는가
            {
                transform.position += (Vector3)move;
            }
            _anim.SetBool("Move", true);
        }
        if(_type == 0)
        {
            transform.position = this.transform.position;
            _anim.SetBool("Move", false);
        }
        transform.localScale = scale;
#endif
    }

    public void OnTriggerEnter2D(Collider2D fruit)
    {
        _audioSource.Play();
        EatAnimation();
        if (fruit.transform.CompareTag("gibon"))
        {
            _hungerScript.HpUp(HungerBar.FruitType.gibon);
            _scoreScript.fruitScore(GameScore.FruitScore.gibon);
        }
        if (fruit.transform.CompareTag("gumgum"))
        {
            _hungerScript.HpUp(HungerBar.FruitType.gumgum);
            _scoreScript.fruitScore(GameScore.FruitScore.gumgum);
        }
        if (fruit.transform.CompareTag("ggGoRrrrrr"))
        {
            _hungerScript.HpUp(HungerBar.FruitType.ggoRrrrrr);
            _scoreScript.fruitScore(GameScore.FruitScore.ggoRrrrrr);
        }
        if (fruit.transform.CompareTag("aku"))
        {
            _hungerScript.HpUp(HungerBar.FruitType.aku);
            _scoreScript.fruitScore(GameScore.FruitScore.aku);
            StartCoroutine(AkuFruitTimer());
        }
        if (fruit.transform.CompareTag("masit"))
        {
            _hungerScript.HpUp(HungerBar.FruitType.masit);
            _scoreScript.fruitScore(GameScore.FruitScore.masit);
        }
        if (fruit.transform.CompareTag("kunchuk"))
        {
            _hungerScript.HpUp(HungerBar.FruitType.kumchuk);
            _scoreScript.fruitScore(GameScore.FruitScore.kumchuk);
            StartCoroutine(KumchukFruitTimer());
        }
    }

    private void EatAnimation()
    {
        _eat = FruitEat();
        _eatingType = true;

        StartCoroutine(_eat);
    }

    IEnumerator FruitEat()
    {
        _anim.SetBool("Eat", true);
        yield return new WaitForSeconds(0.5f);
        _anim.SetBool("Eat", false);
    }

    IEnumerator AkuFruitTimer()
    {
        _moveSpeed = _moveStop;
        yield return new WaitForSeconds(_stopTime);

        if (_moveSpeed == _moveStop)
        {
            _moveSpeed = 3.3f;
            yield break;
        }
    }

    IEnumerator KumchukFruitTimer()
    {
        _moveSpeed = _moveHurry;
        yield return new WaitForSeconds(_stopTime);

        if (_moveSpeed == _moveHurry)
        {
            _moveSpeed = 3.3f;
            yield break;
        }
    }

}
