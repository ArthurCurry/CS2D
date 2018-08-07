using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {
    public float hp=100f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void TakeDamage(float damage)
    {
        hp -= damage;
        if (hp <= 0)
            Destroy(this.gameObject);
        //Debug.Log(hp);
    }
}
