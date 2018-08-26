using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponFire : MonoBehaviour {
    AudioSource audioSource;
    public float freq;
    public float waitTime;
    public float damage;
    WeaponData weaponData;
    int ammoPerMagazine;
    int totalAmmo;
    float reloadingTime;
    int currentAIM;
    int leftAmmo;
    GameObject reloadText;
    LineRenderer line;
	// Use this for initialization
	void Start () {
        AmmoDisplay();
        if (transform.parent.parent.tag == "Player" || transform.parent.parent.tag == "Teammate")
            GetComponentInChildren<EnemyShoot>().enabled = false;
        audioSource = GetComponent<AudioSource>();
        freq = -5f;
        weaponData = GetComponent<WeaponData>();
        reloadText = GameObject.Find("Reloading");
        ammoPerMagazine = weaponData.ammoPerMagazine;
        totalAmmo = weaponData.totalAmmo;
        reloadingTime = weaponData.reloadingTime;
        currentAIM = ammoPerMagazine;
        leftAmmo = totalAmmo - currentAIM;
	}
	
	// Update is called once per frame
	void Update () {
        AmmoDisplay();
        Fire();
	}

    void Fire()
    {
        if (Input.GetButton("Fire1") && (Time.time - waitTime) >= freq&&currentAIM>0&&totalAmmo>0)
        {
            audioSource.Play();
            currentAIM -= 1;
            totalAmmo -= 1;
            freq = Time.time;
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 targetPos = new Vector2(worldPos.x, worldPos.y);
            Vector2 startPos = new Vector2(transform.position.x, transform.position.y);
            targetPos = (targetPos - startPos) * 10 + startPos;
            RaycastHit2D hit = Physics2D.Linecast(startPos, targetPos, ~LayerMask.GetMask("Water"));
            Debug.DrawLine(startPos, targetPos, Color.white, 20, false);
            if (hit.collider != null && hit.collider.gameObject.tag == "Enemy")
            {
                EnemyHealth enemy = hit.collider.GetComponent<EnemyHealth>();
                enemy.TakeDamage(damage);
            }
        }
        else if(currentAIM<=0)
        {
            StartCoroutine(Reload());
        }
    }

    IEnumerator Reload()
    {
        yield return new WaitForSeconds(reloadingTime);
        currentAIM = ammoPerMagazine;
        leftAmmo = totalAmmo - currentAIM;
        StopAllCoroutines();
    }

    void AmmoDisplay()
    {
        if (transform.parent.parent.tag == "Player")
        {
            GameObject.Find("Player").GetComponent<AmmoDisplay>().weaponAIM = currentAIM;
            GameObject.Find("Player").GetComponent<AmmoDisplay>().leftAmmo = leftAmmo;
        }
    }
}
