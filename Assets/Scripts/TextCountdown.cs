using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class TextCountdown : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        StartCoroutine(GetReady());
	}
	
    // call this function to display countdown
    IEnumerator GetReady()
    {
        gameObject.GetComponent<Text>().text = "3";

        yield return new WaitForSeconds(1.0f);

        gameObject.GetComponent<Text>().text = "2";

        yield return new WaitForSeconds(1.0f);

        gameObject.GetComponent<Text>().text = "1";

        yield return new WaitForSeconds(1.0f);

        gameObject.GetComponent<Text>().text = "0";

        yield return new WaitForSeconds(1.0f);

        DestroyImmediate(gameObject);

    }
}
