using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {
    public float damage;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerStay2D(Collider2D coll)
    {
        if(coll.gameObject.tag=="Enemy")
        {
            EnemyHealth enemy = coll.gameObject.GetComponent<EnemyHealth>();
            enemy.TakeDamage(damage);
            //Debug.Log(damage);
        }
        Destroy(this.gameObject, 0.5f);
    }
}
