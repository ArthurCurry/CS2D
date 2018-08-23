using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour {
    private float hp=100f;
	// Use this for initialization
	void Start () {
        GetComponentInChildren<RockerLauncher>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void TakeDamage(float damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            Destroy(this.gameObject);
            GameObject.Find("Player").GetComponent<PlayerHealth>().Score.CTScore += 10;
        }
        //Debug.Log(hp);
    }
}
