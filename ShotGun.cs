using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGun : MonoBehaviour {
    AudioSource audioSource;
    private float freq;
    public float waitTime;
    private float damage;
    public float minDamageDistance;
    public float maxDamage;
    // Use this for initialization
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        freq = -5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && (Time.time - waitTime) >= freq)
        {
            audioSource.Play();
            freq = Time.time;
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 targetPos = new Vector2(worldPos.x, worldPos.y);
            Vector2 startPos = new Vector2(transform.position.x, transform.position.y);
            targetPos = (targetPos - startPos) * 10 + startPos;
            RaycastHit2D hit = Physics2D.Linecast(startPos, targetPos, LayerMask.GetMask("Flesh"));
            if (hit.collider != null && hit.collider.gameObject.tag == "Enemy")
            {
                damage = maxDamage*(minDamageDistance - (hit.collider.transform.position - transform.position).magnitude) / minDamageDistance;
                if ((hit.collider.transform.position - transform.position).magnitude > minDamageDistance)
                    damage = 0f;
                Debug.Log(damage);
                EnemyHealth enemy = hit.collider.GetComponent<EnemyHealth>();
                enemy.TakeDamage(damage);
            }
        }
    }
}
