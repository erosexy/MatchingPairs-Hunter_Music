using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class HelpWindow : MonoBehaviour
{
    private Rect windowRect0 = new Rect((Screen.width - 400)/2, (Screen.height - 200)/2, 400, 275);
    string guiWindowText, gameMode;
    int totalPlays;
    //private Rect windowRect1 = new Rect(20, 100, 120, 50);

    public void GetNumberOfPlays(int nPlays)
    {
        totalPlays = nPlays;
    }

    public void GetGameMode(string gameMode)
    {
        this.gameMode = gameMode;
    }

    /// <summary>
    /// toda janela precisa de um id, um retângulo para aparecer, uma função para executar ao se clicar nela e um título
    /// </summary>
    void OnGUI()
    {
        var windowSize = GUI.skin.GetStyle("Window");
        windowSize.fontSize = 30;
        windowSize.border.top = 1;
        guiWindowText = "Total of plays: " + totalPlays;
        //player.SetActive(false);
        windowRect0 = GUI.Window(0, windowRect0, DoMyWindow, "GAME OVER"); 
        //windowRect1 = GUI.Window(1, windowRect1, DoMyWindow, "My Window");
        //windowRect2 = GUI.Window(2, windowRect2, DoMyWindow, "UHUL");
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="windowID">id da janela que foi clicada</param>
    void DoMyWindow(int windowID)
    {
        var buttonSize = GUI.skin.GetStyle("Button");
        buttonSize.fontSize = 50;

        var buttonSize2 = GUI.skin.GetStyle("Button");
        buttonSize2.fontSize = 50;

        if (windowID == 0)
        {
            var centeredStyle = GUI.skin.GetStyle("Label");
            centeredStyle.alignment = TextAnchor.UpperCenter; //defina estilos para poder personalizar as janelas
            centeredStyle.fontSize = 45;
            GUI.Label(new Rect(10, 50, 375, 280), guiWindowText, centeredStyle);
            //stopTime();
        }

        if (GUI.Button(new Rect((windowRect0.width - 350) / 2, (windowRect0.height - 60) / 2, 350, 60), "Title screen", buttonSize))
        {
            Debug.Log(Time.timeScale);
            //startTime();
            //Destroy(this);
            SceneManager.LoadScene("Menu");
            print("Got a click in window " + windowID);
        }

        if (GUI.Button(new Rect((windowRect0.width - 350) / 2, (windowRect0.height + 100) / 2, 350, 60), "Play again", buttonSize2) && gameMode.Equals("Easy"))
        {
            Debug.Log(Time.timeScale);
            //startTime();
            Destroy(this);
            SceneManager.LoadScene("Easy");
            print("Got a click in window " + windowID);
        }
        else if (GUI.Button(new Rect((windowRect0.width - 350) / 2, (windowRect0.height + 100) / 2, 350, 60), "Play again", buttonSize2) && gameMode.Equals("Medium"))
        {
            Debug.Log(Time.timeScale);
            //startTime();
            Destroy(this);
            SceneManager.LoadScene("Medium");
            print("Got a click in window " + windowID);
        }
        else if (GUI.Button(new Rect((windowRect0.width - 350) / 2, (windowRect0.height + 100) / 2, 350, 60), "Play again", buttonSize2) && gameMode.Equals("Hard"))
        {
            Debug.Log(Time.timeScale);
            //startTime();
            Destroy(this);
            SceneManager.LoadScene("Hard");
            print("Got a click in window " + windowID);
        }



        //GUI.DragWindow(new Rect(0, 0, 10000, 10000)); //permite arrastar a janela
    }

    //public void stopTime()
    //{
    //    Time.timeScale = 0.0f;
    //}

    //public void startTime()
    //{
    //    Time.timeScale = 1.0f;
    //}
}