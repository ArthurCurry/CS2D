using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour {
    AudioSource audioSource;
    EnemyMovements enemyMovements;
    public float freq;
    public float waitTime;
    public float damage;
    bool insight;
	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
        enemyMovements = GetComponentInParent<EnemyMovements>();
        freq = GetComponent<WeaponFire>().freq;
        waitTime = GetComponent<WeaponFire>().waitTime;
        damage = GetComponent<WeaponFire>().damage;
        if(transform.parent.parent.tag=="Enemy")
            GetComponent<WeaponFire>().enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
        insight = enemyMovements.insight;
        if (insight)
            Shoot();
	}

    void Shoot()
    {
        if((Time.time-waitTime)>=freq)
        {
            Vector2 currentPos = new Vector2(transform.position.x, transform.position.y);
            audioSource.Play();
            freq = Time.time;
            Vector2 targetPos = Quaternion.Euler(0, 0, Random.Range(-20, 20))*(new Vector2(transform.up.x, transform.up.y) * 10 + currentPos);
            RaycastHit2D hit = Physics2D.Linecast(currentPos, targetPos, ~LayerMask.GetMask("Water"));
            if(hit.collider!=null&&(hit.collider.gameObject.tag=="Player"||hit.collider.gameObject.tag=="Teammate"))
            {
                PlayerHealth playerHealth = hit.collider.GetComponent<PlayerHealth>();
                playerHealth.PlayerTakeDamage(damage);
            }
        }
    }
}
