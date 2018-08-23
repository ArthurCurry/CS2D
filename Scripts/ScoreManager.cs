using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {
    public Text T;
    public Text CT;
    public float TScore=0;
    public float CTScore=0;
    public int CTdeadNumber=0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        T.text = "T:" + TScore;
        CT.text = "CT:" + CTScore;
	}
}
