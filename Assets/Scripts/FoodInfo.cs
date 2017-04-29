using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodInfo : MonoBehaviour {

    public GameObject listEasy, listMedium, listHard;

    public void ShowEasyCards()
    {
        listEasy.SetActive(true);
        listMedium.SetActive(false);
        listHard.SetActive(false);
    }

    public void ShowMediumCards()
    {
        listMedium.SetActive(true);
        listEasy.SetActive(false);
        listHard.SetActive(false);
    }

    public void ShowHardCards()
    {
        listHard.SetActive(true);
        listMedium.SetActive(false);
        listEasy.SetActive(false);
    }

	void Start () {
        listEasy.SetActive(false);
        listMedium.SetActive(false);
        listHard.SetActive(false);
    }
}
