using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    GameObject player;
    Vector3 direction;
    public float followSpeed;
	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
        direction = player.transform.position - transform.position;
        direction.x = direction.y = 0;
	}
	
	// Update is called once per frame
	void Update () {
        Follow();
	}

    void Follow()
    {
        Vector3 targetPos = player.transform.position;
        Vector3 currentPos = transform.position;
        transform.position = targetPos - direction;
    }
}
