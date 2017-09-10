using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class systemInfo : MonoBehaviour {

    string text;
    Text graphicsName;

	// Use this for initialization
	void Start () {
        graphicsName = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        text = (SystemInfo.graphicsDeviceName);
        graphicsName.text = text;

    }
}
