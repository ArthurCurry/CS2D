using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeammateMovements : MonoBehaviour {
    private GameObject player;
    private Rigidbody2D rb;
    private float speed = 1.3f;
    private Vector2 direction;
    public bool enemyFound=false;
    public Vector2 playerPosition;
    public Vector2 targetPosition;
    public Vector2 currentPosition;
    public Vector2 aimPosition;
    public float stopDistance;
    public float vision = 2;
	// Use this for initialization
	void Start () {
        player = GameObject.FindWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Move();
	}

    void Move()
    {
        Aim();
        playerPosition.Set(player.transform.position.x, player.transform.position.y);
        currentPosition.Set(transform.position.x, transform.position.y);
        targetPosition = (playerPosition - currentPosition).normalized;
        if (targetPosition.magnitude <stopDistance)
        {
            targetPosition = Vector2.zero;
        }
        targetPosition =Quaternion.Euler(new Vector3(0, 0, Random.Range(-20, 20)))*targetPosition;
        rb.MovePosition(currentPosition + targetPosition * speed * Time.deltaTime);
        if (enemyFound == false)
        {
            direction = playerPosition - currentPosition;
        }
        else
            direction = aimPosition - currentPosition;
        direction.Normalize();
        float targetAngle = Mathf.Atan2(-direction.x, direction.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, targetAngle), 1f);
        //Debug.Log(enemyFound);
    }

    void Aim()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        for(int i=0;i<enemies.Length;i++)
        {
            if((enemies[i].transform.position-transform.position).magnitude<vision)
            {
                enemyFound = true;
                aimPosition.Set(enemies[i].transform.position.x, enemies[i].transform.position.y);
            }
            else
            {
                enemyFound = false;
            }
        }
    }
    /*void Fire()
    {

    }*/
    
    /*void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Enemy")
        {
            enemyFound = true;
            aimPosition.Set(collider.transform.position.x, collider.transform.position.y);
        }
        else
            enemyFound = false;
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.gameObject.tag=="Enemy")
        {
            enemyFound = false;
            aimPosition.Set(player.transform.position.x, player.transform.position.y);
        }
    }*/
}
