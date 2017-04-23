using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Card : MonoBehaviour {

    public static bool DO_NOT = false;

    [SerializeField]
    private int _state;
    [SerializeField]
    private int _cardValue;
    [SerializeField]
    private bool _initialized = false;

    private Sprite _cardBack;
    private Sprite _cardFace;

    private AudioSource flipCardSfx;

    private GameObject _manager;
    public static int cartasViradas = 0;
    public static string nome = "";
    public static bool checaCartas = true;

    private bool isFlipSfx = false;

    void Start()
    {
        _state = 1;
        _manager = GameObject.FindGameObjectWithTag("Manager");
    }

    public void setupGraphics()
    {
        _cardBack = _manager.GetComponent<GameManagerEasy>().getCardBack();
        _cardFace = _manager.GetComponent<GameManagerEasy>().getCardFace (_cardValue);

        flipCard();
    }

    public void setupGraphicsEasy()
    {
        _cardBack = _manager.GetComponent<GameManagerEasy>().getCardBack();
        _cardFace = _manager.GetComponent<GameManagerEasy>().getCardFace(_cardValue);

        flipCardSfx = _manager.GetComponent<GameManagerEasy>().flipCard;

        flipCard();

        StartCoroutine(ShowCards());
    }

    public void setupGraphicsMedium()
    {
        _cardBack = _manager.GetComponent<GameManagerMedium>().getCardBack();
        _cardFace = _manager.GetComponent<GameManagerMedium>().getCardFace(_cardValue);

        flipCardSfx = _manager.GetComponent<GameManagerMedium>().flipCard;

        flipCard();

        StartCoroutine(ShowCards());
    }

    public void setupGraphicsHard()
    {
        _cardBack = _manager.GetComponent<GameManagerHard>().getCardBack();
        _cardFace = _manager.GetComponent<GameManagerHard>().getCardFace(_cardValue);

        flipCardSfx = _manager.GetComponent<GameManagerHard>().flipCard;

        flipCard();

        StartCoroutine(ShowCards());
    }

    public void flipCard()
    {
        if (isFlipSfx)
        {
            flipCardSfx.Play();
        }
        isFlipSfx = true;
        checaCartas = true;
        if (cartasViradas == 0)
        {
            if (_state == 0)
            {
                _state = 1;
                cartasViradas++;
                nome = EventSystem.current.currentSelectedGameObject.name;
                Debug.Log(nome);
            }
            else if (_state == 1)
            {
                _state = 0;
            }

            if (_state == 0 && !DO_NOT)
            {
                GetComponent<Image>().sprite = _cardBack;
            }
            else if (_state == 1 && !DO_NOT)
            {
                GetComponent<Image>().sprite = _cardFace;
            }
        }
        else if(nome.Equals(EventSystem.current.currentSelectedGameObject.name))
        {
            //gameObject.GetComponent<Button>().interactable = false;
            Debug.Log("CLICA EM OUTRA");
            checaCartas = false;
        }
        else
        {
            if (_state == 0)
            {
                _state = 1;
                cartasViradas++;
                nome = EventSystem.current.currentSelectedGameObject.name;
                Debug.Log(nome);
            }
            else if (_state == 1)
            {
                _state = 0;
            }

            if (_state == 0 && !DO_NOT)
            {
                GetComponent<Image>().sprite = _cardBack;
            }
            else if (_state == 1 && !DO_NOT)
            {
                GetComponent<Image>().sprite = _cardFace;
            }
        }
    }

    public int cardValue
    {
        get { return _cardValue; }
        set { _cardValue = value; }
    }

    public int state
    {
        get { return _state; }
        set { _state = value; }
    }

    public bool initialized
    {
        get { return _initialized; }
        set { _initialized = value; }
    }

    public void falseCheck()
    {
        StartCoroutine(pause());
        cartasViradas = 0;
        //nome = "";
    }

    IEnumerator pause()
    {
        if(SceneManager.GetActiveScene().name == "Easy")
        {
            _manager.GetComponent<GameManagerEasy>().stopButtons();
            yield return new WaitForSeconds(1);
            if (_state == 0)
            {
                GetComponent<Image>().sprite = _cardBack;
            }
            else if (_state == 1)
            {
                GetComponent<Image>().sprite = _cardFace;
            }
            DO_NOT = false;
            _manager.GetComponent<GameManagerEasy>().startButtons();
        }
        else if(SceneManager.GetActiveScene().name == "Medium")
        {
            _manager.GetComponent<GameManagerMedium>().stopButtons();
            yield return new WaitForSeconds(1);
            if (_state == 0)
            {
                GetComponent<Image>().sprite = _cardBack;
            }
            else if (_state == 1)
            {
                GetComponent<Image>().sprite = _cardFace;
            }
            DO_NOT = false;
            _manager.GetComponent<GameManagerMedium>().startButtons();
        }
        else if(SceneManager.GetActiveScene().name == "Hard")
        {
            _manager.GetComponent<GameManagerHard>().stopButtons();
            yield return new WaitForSeconds(1);
            if (_state == 0)
            {
                GetComponent<Image>().sprite = _cardBack;
            }
            else if (_state == 1)
            {
                GetComponent<Image>().sprite = _cardFace;
            }
            DO_NOT = false;
            _manager.GetComponent<GameManagerHard>().startButtons();
        }
    }


    //mostra as cartas por um tempo para que o jogador tenha chance de decorá-las
    IEnumerator ShowCards()
    {
        GetComponent<Image>().sprite = _cardFace;
        GetComponent<Button>().enabled = false;
        yield return new WaitForSeconds(4);
        GetComponent<Image>().sprite = _cardBack;
        GetComponent<Button>().enabled = true;
    }
}
