using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour {
    private Rigidbody2D rb;
    private Quaternion rotation;
    public float speed=1.0f;
    public Vector3 aimPosition;
    public GameObject pointer;
    private Vector2 movement;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        pointer = GameObject.Find("Pointer");
        Cursor.visible = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Move();
	}

    void Move()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        movement.Set(h, v);
        movement = movement.normalized* speed*Time.deltaTime;
        Vector2 currentPos = new Vector2(transform.position.x, transform.position.y);
        rb.MovePosition(currentPos + movement);
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pointer.transform.position = new Vector3(worldPos.x, worldPos.y, 0);
        Vector3 direction = worldPos - transform.position;
        direction.z = 0f;
        direction.Normalize();
        float targetAngle = Mathf.Atan2(-direction.x, direction.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, targetAngle), 1f);
    }
}
