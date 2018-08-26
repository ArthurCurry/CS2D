using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour {
    WeaponPurchase weaponPurchase;
    public float enemyHP=100f;
	// Use this for initialization
	void Start () {
        if(GetComponentInChildren<RockerLauncher>())
        {
            GetComponentInChildren<RockerLauncher>().enabled = false;
        }
        weaponPurchase = GameObject.Find("PurchaseSystem").GetComponent<WeaponPurchase>();
	}
	
	// Update is called once per frame
	void Update () {
        Die();
	}

    public void TakeDamage(float damage)
    {
        enemyHP -= damage;
        //Debug.Log(hp);
    }

    void Die()
    {
        if (enemyHP <= 0f)
        {
            Debug.Log("dead");
            weaponPurchase.currentMoney += 500f;
            GameObject.Find("Player").GetComponent<PlayerHealth>().Score.CTScore += 10;
            Destroy(this.gameObject);
        }
    }
}
