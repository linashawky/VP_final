using UnityEngine;
using System.Collections;

public class GameMenu : MonoBehaviour
{
    // 200x300 px window will apear in the center of the screen.
    private Rect windowRect = new Rect((Screen.width - 200) / 2, (Screen.height - 300) / 2, 250, 200);
    // Only show it if needed.
    public bool show = false;
    public string inputText="";
    void OnGUI()
    {
        if (show)
            windowRect = GUI.Window(0, windowRect, DialogWindow, "Warning");
    }

    // This is the actual window.
    void DialogWindow(int windowID)
    {
        float y = 20;
        GUI.Label(new Rect(15, y, windowRect.width, 20), inputText);

        if (GUI.Button(new Rect(5, y+100, windowRect.width - 10, 20), "Ok"))
        {
          //  Application.LoadLevel(0);
            show = false;
        }

        /*if (GUI.Button(new Rect(5, y, windowRect.width - 10, 20), "Exit"))
        {
            Application.Quit();
            show = false;
        }*/
    }

    // To open the dialogue from outside of the script.
    public void Open()
    {
        show = true;
    }
}