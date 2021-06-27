using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StackController : MonoBehaviour
{
    public static InputField input;
    public static Button pushButton;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void push()
    {
        Debug.Log("input: " + input);
        if (string.IsNullOrEmpty(input.text))
        {

        }
    }

}
