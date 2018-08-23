using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponFire : MonoBehaviour {
    AudioSource audioSource;
    public float freq;
    public float waitTime;
    public float damage;
    LineRenderer line;
	// Use this for initialization
	void Start () {
        if (transform.parent.parent.tag == "Player" || transform.parent.parent.tag == "Teammate")
            GetComponentInChildren<EnemyShoot>().enabled = false;
        audioSource = GetComponent<AudioSource>();
        freq = -5f;
	}
	
	// Update is called once per frame
	void Update () {
        Fire();
	}

    void Fire()
    {
        if (Input.GetButton("Fire1") && (Time.time - waitTime) >= freq)
        {
            audioSource.Play();
            freq = Time.time;
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 targetPos = new Vector2(worldPos.x, worldPos.y);
            Vector2 startPos = new Vector2(transform.position.x, transform.position.y);
            targetPos = (targetPos - startPos) * 10 + startPos;
            RaycastHit2D hit = Physics2D.Linecast(startPos, targetPos, ~LayerMask.GetMask("Water"));
            Debug.DrawLine(startPos, targetPos, Color.white, 20, false);
            if (hit.collider != null && hit.collider.gameObject.tag == "Enemy")
            {
                Debug.Log(hit.collider.gameObject.name);
                Debug.Log(targetPos);
                EnemyHealth enemy = hit.collider.GetComponent<EnemyHealth>();
                enemy.TakeDamage(damage);
            }
        }
    }
}
