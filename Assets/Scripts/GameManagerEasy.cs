using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.EventSystems;

public class GameManagerEasy : MonoBehaviour {

    public Sprite[] cardFace;
    public Sprite cardBack;
    public GameObject[] cards;
    public GameObject gameOverWindow;
    public Text matchText, gameTimeText;

    private bool _init = false;
    private int _matches = 12, _matchesGot = 0;
    private int nPlays = 0;
    private float playedTime = 0.0f, showCardsTime = 3.0f;

    //private string nome = "";

    // Update is called once per frame
    void Update () {
        if (!_init){
            initializeCards();
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (!Card.checaCartas)
            {
                Debug.Log("Reporta");
            }
            else
                checkCards();
        }
        playedTime += Time.deltaTime;
        gameTimeText.text = "Game starts in: " + (showCardsTime - Mathf.RoundToInt(playedTime)).ToString();
        if(Mathf.RoundToInt(playedTime) == 4.0f)
        {
            Destroy(gameTimeText);
        }
    }

    private void initializeCards()
    {
        for (int id = 0; id < 2; id++)
        {
            for (int i = 1; i < 13; i++)
            {
                bool test = false;
                int choice = 0;
                while (!test)
                {
                    choice = Random.Range(0, cards.Length);
                    test = !(cards[choice].GetComponent<Card>().initialized);
                }
                cards[choice].GetComponent<Card>().cardValue = i;
                cards[choice].GetComponent<Card>().initialized = true;
            }
        }
        
        if (!_init)
            _init = true;

        foreach (GameObject c in cards)
            c.GetComponent<Card>().setupGraphicsEasy();
    }

    public Sprite getCardBack()
    {
        return cardBack;
    }

    public Sprite getCardFace(int i)
    {
        return cardFace [i - 1];
    }

    void checkCards()
    {
        List<int> c = new List<int>();

        for (int i = 0; i < cards.Length; i++)
        {
            if (cards [i].GetComponent<Card>().state == 1)
            {
                c.Add (i);
            }
        }

        if(c.Count == 2)
        {
            cardComparison(c);
        }
    }

    void cardComparison(List<int> c)
    {
        Card.DO_NOT = true;

        int x = 0;
        nPlays++;

        if (cards[c[0]].GetComponent<Card>().cardValue == cards[c[1]].GetComponent<Card>().cardValue)
        { 
            x = 2;
            _matchesGot++;
            //_matches--;
            //matchText.text = "Number of matches: " + _matches;
            matchText.text = _matchesGot + "/" + _matches;
            //nome = "";
            if (_matches == _matchesGot)
            {
                print("Number of plays: " + nPlays);
                gameOverWindow.GetComponent<HelpWindow>().enabled = true;
                gameOverWindow.GetComponent<HelpWindow>().GetNumberOfPlays(nPlays);
                gameOverWindow.GetComponent<HelpWindow>().GetGameMode("Easy");
                //SceneManager.LoadScene("Menu");
            }
        }

        for (int i = 0; i < c.Count; i++)
        {
            cards[c[i]].GetComponent<Card>().state = x;
            cards[c[i]].GetComponent<Card>().falseCheck();
        }
    }

    public void stopButtons()
    {
        for(int i = 0; i < cards.Length; i++)
        {
            cards[i].GetComponent<Button>().interactable = false;
        }
        print("stop");
    }

    public void startButtons()
    {
        for (int i = 0; i < cards.Length; i++)
        {
            cards[i].GetComponent<Button>().interactable = true;
        }
        print("start");
    }
}
