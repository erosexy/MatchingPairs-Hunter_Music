using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBehavior : MonoBehaviour {
    public GameObject[] difficultyButtons;
    public GameObject glosssaryButton;

    void Awake()
    {
        for(int i = 0; i < difficultyButtons.Length; i++)
        {
            difficultyButtons[i].SetActive(false);
        }
    }

	public void TriggerMenuBehavior(int i)
    {
        switch (i){
            default:
            case (0):
                //SceneManager.LoadScene("Level");
                Debug.Log("Start works");
                SetDifficultyButtonsVisible();
                break;
            case (1):
                Debug.Log("Quit works");
                Application.Quit();
                break;
            case (2):
                SceneManager.LoadScene("Easy");
                Debug.Log("Easy mode!");
                print("Easy mode!");
                break;
            case (3):
                SceneManager.LoadScene("Medium");
                Debug.Log("Medium mode!");
                print("Medium mode!");
                break;
            case (4):
                SceneManager.LoadScene("Hard");
                Debug.Log("Hard mode!");
                print("Hard mode!");
                break;
            case (5):
                SceneManager.LoadScene("FoodInfo");
                Debug.Log("FoodInfo!");
                print("Glossary!");
                break;
        }
    }

    void SetDifficultyButtonsVisible()
    {
        for (int i = 0; i < difficultyButtons.Length; i++)
        {
            difficultyButtons[i].SetActive(true);
        }
    }
}
