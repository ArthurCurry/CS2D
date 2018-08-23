using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {
    public float hp=100f;
    public ScoreManager Score;
	// Use this for initialization
	void Start () {
        Score = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PlayerTakeDamage(float damage)
    {
        hp -= damage;
        if(hp<=0)
        {
            Score.TScore += 10;
            Score.CTdeadNumber += 1;
            Destroy(this.gameObject);
        }
    }
}
