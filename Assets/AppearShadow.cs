using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.XR.WSA.Input;

public class AppearShadow : MonoBehaviour {

    //public GameObject whatever;
    public GameObject[] Scubes;
    public GameObject Line;
    int[] activeList = { 9, 9, 9 };
    int[] list1 = { 0, 2, 4, 3, 4, 2, 3, 5, 1, 0, 1, 3, 2, 5, 0, 5, 1, 4 };
    int[] list2 = { 0, 2, 4, 3, 4, 2, 3, 5, 1, 0, 1, 3, 2, 5, 0, 5, 1, 4 };
    int[] list3 = { 0, 2, 4, 3, 4, 2, 3, 5, 1, 0, 1, 3, 2, 5, 0, 5, 1, 4 };
    int[] list4 = { 1, 2, 0, 1, 2, 2, 0, 1, 0, 0, 1, 1, 2, 1, 2, 2, 0, 0 };
    int[] list5 = { 2, 2, 1, 2, 1, 0, 1, 0, 0, 2, 1, 0, 0, 1, 0, 2, 1, 2 };
    int[] list6 = { 2, 2, 0, 1, 0, 0, 1, 2, 1, 1, 0, 1, 0, 1, 0, 2, 2, 2 };
    int[] cali = { 0, 2, 4, 3, 4, 2, 3, 5, 1, 0, 1, 3, 2, 5, 0, 5, 1, 4 };
    private GestureRecognizer recognizer;
    bool clear = true;
    int counter = 0;

    //for doubleclick:
    const float DELAY = 0.5f;

    //public GestureRecognizer recognizer { get; private set; }


    void Start()
    {

        recognizer = new GestureRecognizer();
        recognizer.StartCapturingGestures();

        recognizer.SetRecognizableGestures(GestureSettings.Tap | GestureSettings.DoubleTap);
        recognizer.TappedEvent += (source, tapCount, ray) =>
        {
            if (tapCount == 1)
                Invoke("SingleTap", DELAY);
            else if (tapCount == 2)
            {
                CancelInvoke("SingleTap");
                Advance();
            }

        };
    }

    //For list 1
    public void List1()
    {
        //sets the pre-shuffled group
        if (clear)
        {
            activeList = list1;
            counter = 0;
        }
        else
        {
            Scubes[activeList[counter - 1]].SetActive(false);
            clear = true;
            activeList = list1;
            counter = 0;
        }

        //changes line color
        Line.GetComponent<Renderer>().material.color = Color.blue;


        //creates and prints the group
        string path = Path.Combine(Application.persistentDataPath, "Order.txt");
        using (TextWriter writer = File.AppendText(path))
        {
            writer.WriteLine("List/Group 1");
            Debug.Log("Works");

        }


    }

    public void List2()
    {
        if (clear)
        {
            activeList = list2;
            counter = 0;
        }
        else
        {
            Scubes[activeList[counter - 1]].SetActive(false);
            clear = true;
            activeList = list2;
            counter = 0;
        }

        Line.GetComponent<Renderer>().material.color = Color.blue;

        string path = Path.Combine(Application.persistentDataPath, "Order.txt");
        using (TextWriter writer = File.AppendText(path))
        {
            writer.WriteLine("List/Group 2");
            Debug.Log("Works");

        }


    }

    public void List3()
    {
        if (clear)
        {
            activeList = list3;
            counter = 0;
        }
        else
        {
            Scubes[activeList[counter - 1]].SetActive(false);
            clear = true;
            activeList = list3;
            counter = 0;
        }

        Line.GetComponent<Renderer>().material.color = Color.blue;


        string path = Path.Combine(Application.persistentDataPath, "Order.txt");
        using (TextWriter writer = File.AppendText(path))
        {
            writer.WriteLine("List/Group 3");
            Debug.Log("Works");

        }


    }

    public void List4()
    {
        if (clear)
        {
            activeList = list4;
            counter = 0;
        }
        else
        {
            Scubes[activeList[counter - 1]].SetActive(false);
            clear = true;
            activeList = list4;
            counter = 0;
        }

        Line.GetComponent<Renderer>().material.color = Color.blue;

        string path = Path.Combine(Application.persistentDataPath, "Order.txt");
        using (TextWriter writer = File.AppendText(path))
        {
            writer.WriteLine("List/Group 4");
            Debug.Log("Works");

        }


    }

    public void List5()
    {
        if (clear)
        {
            activeList = list5;
            counter = 0;
        }
        else
        {
            Scubes[activeList[counter - 1]].SetActive(false);
            clear = true;
            activeList = list5;
            counter = 0;
        }

        Line.GetComponent<Renderer>().material.color = Color.blue;

        string path = Path.Combine(Application.persistentDataPath, "Order.txt");
        using (TextWriter writer = File.AppendText(path))
        {
            writer.WriteLine("List/Group 5");
            Debug.Log("Works");

        }


    }

    public void List6()
    {
        if (clear)
        {
            activeList = list6;
            counter = 0;
        }
        else
        {
            Scubes[activeList[counter - 1]].SetActive(false);
            clear = true;
            activeList = list6;
            counter = 0;
        }

        Line.GetComponent<Renderer>().material.color = Color.blue;

        string path = Path.Combine(Application.persistentDataPath, "Order.txt");
        using (TextWriter writer = File.AppendText(path))
        {
            writer.WriteLine("List/Group 6");
            Debug.Log("Works");

        }


    }

    public void Calibration()
    {
        if (clear)
        {
            activeList = cali;
            counter = 0;
            Debug.Log("Works");
        }
        else
        {
            Scubes[activeList[counter - 1]].SetActive(false);
            clear = true;
            activeList = cali;
            counter = 0;
        }

        Line.GetComponent<Renderer>().material.color = Color.blue;

        string path = Path.Combine(Application.persistentDataPath, "Order.txt");
        using (TextWriter writer = File.AppendText(path))
        {
            writer.WriteLine("Calibration:  10m, 20m, 30m, 25m, 30m, 20m, 25m, 35m, 15m, 10m, 15m, 25m, 20m, 35m, 10m, 35m, 15m, 30m");
            Debug.Log("Works");
        }
    }

    //Makes cubes move on
    public void Advance()
    {
        if (clear)
        {
            Scubes[activeList[counter]].SetActive(true);
            counter++;
            clear = false;
        }
    }

    
    public void Ready()
    {
        if (counter < 18)
        {
            Scubes[activeList[counter - 1]].SetActive(false);
            clear = true;
        }
        else if (counter == 18)
        {
            Scubes[activeList[counter - 1]].SetActive(false);
            clear = true;
            Line.GetComponent<Renderer>().material.color = Color.red;
        }
        if (counter == 9 && clear == true)
        {
            Line.GetComponent<Renderer>().material.color = Color.yellow;
        }
    }


}
