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

    public void push()
    {
        Debug.Log("input: " + input.text);
        if (string.IsNullOrEmpty(input.text))
        {
            UnityEditor.EditorUtility.DisplayDialog("WARNING!", "Please input something", "OK");
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
                UnityEditor.EditorUtility.DisplayDialog("Stack overflow", "Exceeded the Stack memory limit", "OK");
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
            UnityEditor.EditorUtility.DisplayDialog("WARNING!", "Nothing in stack to view", "OK");
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
            UnityEditor.EditorUtility.DisplayDialog("WARNING!", "Nothing in stack to pop", "OK");
        }

    }



    }
