using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class StackController : MonoBehaviour
{
    public GameObject newCanvas;
    // public GameObject button;
    public GameObject notification;
    public Button Consoles;
    public  InputField input;
    public  Button pushButton;
    private int Stackcounter=0;
    public Stack <Button> StackButton;
    // Start is called before the first frame update
    void Start()
    {
        StackButton = new Stack<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Back()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Start");
    }
    public void push()
    {
        Debug.Log("input: " + input.text);
        if (string.IsNullOrEmpty(input.text))
        {
            notification.GetComponent<GameMenu>().inputText = "Please input something";
            notification.GetComponent<GameMenu>().show = true;

            //   StackController.DisplayDialog("WARNING!", "Please input something", "OK");
            /*#if UNITY_EDITOR
                        UnityEditor.EditorUtility.DisplayDialog("WARNING!", "c", "OK");
            #else
                        StackController.DisplayDialog("WARNING!", "Please input something", "OK");

            #endif*/
        }
        else
        {
            if (Stackcounter <= 17)
            {
                Button newButton =Instantiate(pushButton, new Vector3(-284, -350+(38*Stackcounter), 0), Quaternion.identity);
                //newButton.GetComponentInChildren<Text>.text = input.text;
                newButton.name = "Button " +Stackcounter;
                newButton.GetComponentInChildren<Text>().text = input.text;
                newButton.transform.SetParent(newCanvas.transform, false);
                StackButton.Push(newButton);
                Stackcounter++;
                /*  Button newButton = Instantiate(pushButton) as Button;
                  newButton.Text.text = input.text;*/
            }
            else
            {
                notification.GetComponent<GameMenu>().inputText = "Exceeded the stack memory limit";
                notification.GetComponent<GameMenu>().show = true;
                /*#if UNITY_EDITOR
                            UnityEditor.EditorUtility.DisplayDialog("Stack overflow", "Exceeded the Stack memory limit", "OK");
                #else
                                StackController.DisplayDialog("Stack overflow", "Exceeded the Stack memory limit", "OK");

                #endif*/

            }
        }
    }
    public void peek()
    {

        if (StackButton.Count>0)
        {
            Consoles.GetComponentInChildren<Text>().text = StackButton.Peek().GetComponentInChildren<Text>().text;
        }
        else
        {
            notification.GetComponent<GameMenu>().inputText = "Nothing in stack to view";
            notification.GetComponent<GameMenu>().show = true;


            /*#if UNITY_EDITOR
                        UnityEditor.EditorUtility.DisplayDialog("WARNING!", "Nothing in stack to view", "OK");
            #else
                        StackController.DisplayDialog("WARNING!", "Nothing in stack to view", "OK");

            #endif*/
        }


    }

    public void pop()
    {
        if (StackButton.Count > 0)
        { 
            Consoles.GetComponentInChildren<Text>().text = StackButton.Peek().GetComponentInChildren<Text>().text;
            Button poped= StackButton.Pop();

           GameObject panelTransform = GameObject.Find(poped.name);
            Destroy(panelTransform);
            Stackcounter--;

        }
        else
        {
            notification.GetComponent<GameMenu>().inputText = "Nothing in stack to pop";
            notification.GetComponent<GameMenu>().show = true;
            /*#if UNITY_EDITOR
                        UnityEditor.EditorUtility.DisplayDialog("WARNING!", "Nothing in stack to pop", "OK");
            #else
                        StackController.DisplayDialog("WARNING!", "Nothing in stack to pop", "OK");

            #endif*/
        }

    }



    }
