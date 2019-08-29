using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpManager : MonoBehaviour {

	private Transform curGameObj = null;
    public Transform listIndicatorUI;
    public Transform trialIndicatorUI;
    public Transform statusIndicatorUI;

    private int[] curList;
    private int[] list1 = { 20, 13, 15, 22, 0, 23, 29, 7, 3, 2, 6, 27, 18, 10, 24, 16, 17, 8, 21, 9, 12, 25, 4, 26, 5, 14, 1, 28, 11, 19 };
    private int[] list2 = { 7, 21, 13, 20, 24, 5, 14, 2, 6, 0, 11, 23, 9, 15, 12, 4, 22, 3, 16, 27, 8, 1, 25, 17, 29, 18, 26, 10, 28, 19 };
    private int[] list3 = { 17, 0, 27, 8, 24, 15, 6, 19, 26, 10, 2, 29, 21, 12, 20, 18, 22, 25, 23, 11, 3, 7, 14, 16, 9, 1, 28, 4, 5, 13 };
    private int[] list4 = { 16, 29, 11, 23, 24, 8, 9, 0, 26, 28, 4, 17, 3, 5, 1, 18, 2, 15, 14, 7, 20, 27, 21, 19, 22, 6, 12, 25, 13, 10 };

    private int listNum = 1;
    private int expNum = 0;

	// Use this for initialization
	void Start () {
        DisableChildren ();
	}

    void Update () {
        Debug.developerConsoleVisible = false;
    }

    public void SetList (int input)
    {
        curGameObj = null;
        expNum = 0;
        DisableChildren();

        listNum = input;
        switch (listNum)
        {
            case 1:
                curList = list1;
                listIndicatorUI.GetComponent<TextMesh>().text = "List 1";
                trialIndicatorUI.GetComponent<TextMesh>().text = "Trial #";
                break;
            case 2:
                curList = list2;
                listIndicatorUI.GetComponent<TextMesh>().text = "List 2";
                trialIndicatorUI.GetComponent<TextMesh>().text = "Trial #";
                break;
            case 3:
                curList = list3;
                listIndicatorUI.GetComponent<TextMesh>().text = "List 3";
                trialIndicatorUI.GetComponent<TextMesh>().text = "Trial #";
                break;
            case 4:
                curList = list4;
                listIndicatorUI.GetComponent<TextMesh>().text = "List 4";
                trialIndicatorUI.GetComponent<TextMesh>().text = "Trial #";
                break;
            default:
                curList = list1;
                listIndicatorUI.GetComponent<TextMesh>().text = "List 1";
                trialIndicatorUI.GetComponent<TextMesh>().text = "Trial #";
                break;
        }
        
    }

	private void DisableChildren ()
	{
		foreach (Transform child in transform)
			child.gameObject.SetActive(false);
	}

	private void Experiment (int expNum, int listNum)
	{
		if (curGameObj != null)
			curGameObj.gameObject.SetActive(false);

        curGameObj = transform.GetChild(curList[expNum]);
        curGameObj.gameObject.SetActive(true);

	}
	
	public void Next ()
	{
		if (expNum >= 0 && expNum < 30)
		{
            int expNumDisplay = expNum + 1;
            trialIndicatorUI.GetComponent<TextMesh>().text = "Trial #" + expNumDisplay.ToString();
			Experiment(expNum, listNum);
            ++expNum;
		}
		else ResetExp();
	}

	public void ResetExp()
	{
		curGameObj = null;
        listNum = 1;
		expNum = 0;
        listIndicatorUI.GetComponent<TextMesh>().text = "List 1";
        trialIndicatorUI.GetComponent<TextMesh>().text = "Trial #";
        statusIndicatorUI.GetComponent<TextMesh>().text = "Reset";
        DisableChildren();
	}
}
