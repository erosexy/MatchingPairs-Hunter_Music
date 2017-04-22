using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ShowCountDown : MonoBehaviour {

    // variables
    private string countdown = "";    
    private bool showCountdown = false;
 
 
    // call this function to display countdown
    IEnumerator GetReady()
    {
        showCountdown = true;

        countdown = "3";
        
        yield return new WaitForSeconds (1.0f);

        countdown = "2";
        yield return new WaitForSeconds(1.0f);

        countdown = "1";
        yield return new WaitForSeconds(1.0f);

        countdown = "GO";
        yield return new WaitForSeconds(1.0f);

        showCountdown = false;
        countdown = "";
    }

    // GUI
    void OnGUI()
    {
        if (showCountdown)
        {
            GUI.color = Color.red;
            GUI.Box(new Rect(Screen.width / 2 - 100, 50, 200, 55), "GET READY");

            // display countdown    
            GUI.color = Color.white;
            GUI.Box(new Rect(Screen.width / 2 - 90, 75, 180, 20), countdown);
        }
    }

    // Use this for initialization
    void Start () {
        StartCoroutine(GetReady());
	}
}
