using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenu : MonoBehaviour
{
    public void Queue()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Queue");
    }
    public void Stack()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Stack");
    }

    public void QuitButton()
    {
        Application.Quit();
        //EditorApplication.Exit(0);
    }
}
