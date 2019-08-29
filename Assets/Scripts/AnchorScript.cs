using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity;

public class AnchorScript : MonoBehaviour {

	public WorldAnchorManager worldAnchorManager;
    public Transform statusIndicatorUI;

	// Use this for initialization
	void Start () {
		Anchor();
	}

	public void Anchor()
	{
		worldAnchorManager.AttachAnchor(this.gameObject);
        statusIndicatorUI.GetComponent<TextMesh>().text = "Anchored";

    }
	
	public void Release()
	{
		worldAnchorManager.RemoveAnchor(this.gameObject);
        statusIndicatorUI.GetComponent<TextMesh>().text = "Released";

    }
}
