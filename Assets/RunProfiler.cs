using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RunProfiler : MonoBehaviour
{
    [Tooltip("How many times should the program repeat, warning large values may cause the program to appear to have frozen.")]
    [SerializeField] long iterations = 524288;
    [SerializeField] TMP_Text text;

    string profileOneDesctription = "\n"
        + "Profile 1 creates a float within the method\n"
        + "this float then stores the value in horizontal input\n";

    string profileTwoDesctription = "\n"
        + "Profile 2 creates a float at the top of the class and reuses it\n"
        + "this float then stores the value in horizontal input\n";

    bool running = false;

    float horizontalInputInClass;

    TimeSpan timeSpan1;
    TimeSpan timeSpan2;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Press SPACE to run iterations, warning iterations will automatically double after each run.");
    }
    void RunOperations() 
    {
        running = true;
        Debug.Log("Running profiles with " + iterations.ToString("n0") + " iterations.");
        
        
        Debug.Log("Beginning Profile 1 Variable within method" + profileOneDesctription);
        timeSpan1 = Profile1();


        Debug.Log("Beginning Profile 2 variable in class" + profileTwoDesctription);
        timeSpan2 = Profile2();

        Debug.Log("P1 took: " + timeSpan1 + ". P2 took: " + timeSpan2);

        string outputMessage = "Time taken\n"
            + "P1 took: " + timeSpan1 + "\n"
            + "P2 took: " + timeSpan2;

        text.text = outputMessage;

        iterations = iterations * 2;
        running = false;
    }
    private void Update()
    {
        if (running) return;
        if (Input.GetKeyDown(KeyCode.Space)) RunOperations();
    }
    // Update is called once per frame
    TimeSpan Profile1() 
    {
        DateTime before = DateTime.Now; ;
        Debug.Log(before);

        for(int i = 0; i < iterations; i++)  Method1();

        DateTime after = DateTime.Now;
        Debug.Log(after);

        TimeSpan duration = after.Subtract(before);

        Debug.Log("Duration in milliseconds: " + duration.Milliseconds);

        return duration;
    }
    void Method1() 
    {
        float horizontalInputInMethod = Input.GetAxis("Horizontal");

    }
    TimeSpan Profile2()
    {
        DateTime before = DateTime.Now; ;
        Debug.Log(before);

        for (int i = 0; i < iterations; i++) Method2();

        DateTime after = DateTime.Now;
        Debug.Log(after);

        TimeSpan duration = after.Subtract(before);

        Debug.Log("Duration in milliseconds: " + duration.Milliseconds);

        return duration;
    }
    void Method2() 
    {
        horizontalInputInClass = Input.GetAxis("Horizontal");
    }
}
