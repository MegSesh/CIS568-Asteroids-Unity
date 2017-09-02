using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreUI : MonoBehaviour {

    Global globalObj;
    GUIText scoreText;

	// Use this for initialization
	void Start () {
        GameObject g = GameObject.Find("GlobalObject");
        globalObj = g.GetComponent<Global>();
        scoreText = gameObject.GetComponent<GUIText>();
	}
	
	// Update is called once per frame
	void Update () {
        scoreText.text = globalObj.score.ToString();
	}
}
