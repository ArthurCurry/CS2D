using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockerLauncher : MonoBehaviour {
    AudioSource audioSource;
    private float freq;
    public float waitTime;
    public float damage;
    public GameObject rocket;
    // Use this for initialization
    void Start()
    {
        if (transform.parent.parent.tag == "Teammate"||transform.parent.parent.tag=="Player")
            GetComponent<EnemyShoot>().enabled = false;
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
            Instantiate(rocket, transform.position, transform.rotation);
        }
    }
}
