using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
//using System.Diagnostics;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class QueueController : MonoBehaviour
{
    public GameObject newCanvas;
    public GameObject notification;
    // public GameObject button;
    public Button Consoles;
    public InputField input;
    public Button pushButton;
    private int Queuecounter = 0;
    Queue<Button> Queuelist ;
   // var Queuelist = new ArrayList(); // recommended
                              // Start is called before the first frame update
void Start()
    {
        Queuelist = new Queue<Button>();

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
            //  QueueController.DisplayDialog("WARNING!", "Please input something", "OK");
            notification.GetComponent<GameMenu>().inputText = "Please input something";
            notification.GetComponent<GameMenu>().show = true;


            /*#if UNITY_EDITOR
                        UnityEditor.EditorUtility.DisplayDialog("WARNING!", "Please input something", "OK");
            #else
                        QueueController.DisplayDialog("WARNING!", "Please input something", "OK");

            #endif*/
        }
        else
        {
            if (Queuecounter <= 17)
            {
                Button newButton = Instantiate(pushButton, new Vector3(-600 + (70 * Queuecounter), 4,0), Quaternion.identity);
                //newButton.GetComponentInChildren<Text>.text = input.text;
                newButton.name = "Button " + Queuecounter;
                newButton.GetComponentInChildren<Text>().text = input.text;
                newButton.transform.SetParent(newCanvas.transform, false);
                Queuelist.Enqueue(newButton);
                Queuecounter++;
                /*  Button newButton = Instantiate(pushButton) as Button;
                  newButton.Text.text = input.text;*/
            }
            else
            {
                notification.GetComponent<GameMenu>().inputText = "Exceeded the queue memory limit";
                notification.GetComponent<GameMenu>().show = true;

                // QueueController.DisplayDialog("Warning", "Window is full", "OK");
                /*#if UNITY_EDITOR
                            UnityEditor.EditorUtility.DisplayDialog("Warning", "Window is full", "OK");
                #else
                                QueueController.DisplayDialog("Warning", "Window is full", "OK");

                #endif*/

            }
        }
    }
    public void peek()
    {

        if (Queuelist.Count > 0)
        {
            Consoles.GetComponentInChildren<Text>().text = Queuelist.Peek().GetComponentInChildren<Text>().text;
        }
        else
        {
            notification.GetComponent<GameMenu>().inputText = "Nothing in queue to view";
            notification.GetComponent<GameMenu>().show = true;

            //  QueueController.DisplayDialog("WARNING!", "Nothing in queue to view", "OK");
            /*#if UNITY_EDITOR
                        UnityEditor.EditorUtility.DisplayDialog("WARNING!", "Nothing in queue to view", "OK");
            #else
                        QueueController.DisplayDialog("WARNING!", "Nothing in queue to view", "OK");

            #endif*/
        }


    }

    public void pop()
    {
        if (Queuelist.Count > 0)
        {
            Consoles.GetComponentInChildren<Text>().text = Queuelist.Peek().GetComponentInChildren<Text>().text;
            Button poped = Queuelist.Dequeue();

            GameObject panelTransform = GameObject.Find(poped.name);
            Destroy(panelTransform);
            Queuecounter--;
            helper();

        }
        else
        {
            notification.GetComponent<GameMenu>().inputText = "Nothing in queue to dequeue";
            notification.GetComponent<GameMenu>().show = true;
            // QueueController.DisplayDialog("WARNING!", "Nothing in queue to dequeue", "OK");

            /*#if UNITY_EDITOR
                        UnityEditor.EditorUtility.DisplayDialog("WARNING!", "Nothing in queue to dequeue", "OK");
            #else
                        QueueController.DisplayDialog("WARNING!", "Nothing in queue to dequeue", "OK");

            #endif*/


        }

    }

    void helper()
    {

        for(int i = 0; i < Queuelist.Count; i++)
        {
            
            Queuelist.ElementAt(i).transform.Translate(-70,0,0);
        }
    }



}
