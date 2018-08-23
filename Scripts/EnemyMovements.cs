using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovements : MonoBehaviour {
    public bool insight;
    public Vector2 lastPosition;
    public float timeCounter;
    public float moveTime;
    float vision = 2f;
    float angle;
    int deadNumber=0;
    List<GameObject> playerTeammate;
    GameObject player;
    ScoreManager scoreManager;
    Rigidbody2D rb;
    Vector3 velocity;
    public GameObject[] patrolPosition;

    // Use this for initialization
    void Start () {
        moveTime = -6f;
        rb = GetComponent<Rigidbody2D>();
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        playerTeammate = new List<GameObject>(GameObject.FindGameObjectsWithTag("Teammate"));
        player = GameObject.FindGameObjectWithTag("Player");
        playerTeammate.Add(player);
        patrolPosition = GameObject.FindGameObjectsWithTag("Patrol");
    }
	
	// Update is called once per frame
	void Update () {
        Aim();
        Move();
	}

    void Aim()
    {
        Vector2 currentPos = new Vector2(transform.position.x, transform.position.y);
        Vector2 aimPos=Vector2.zero;
        Vector2 direction;
        RaycastHit2D hit;
        deadNumber = scoreManager.CTdeadNumber;
        if (playerTeammate != null)
        {
            for (int i = 0; i < playerTeammate.Count;i++)
            {
                if (playerTeammate[i]!=null)
                {
                    if ((playerTeammate[i].transform.position - transform.position).magnitude < vision)
                    {
                        aimPos = new Vector2(playerTeammate[i].transform.position.x, playerTeammate[i].transform.position.y);
                        /*if (hit = Physics2D.Linecast(currentPos, aimPos))
                        {
                            if (hit.collider.gameObject.tag == "Player" || hit.collider.gameObject.tag == "Teammate")
                                insight = true;
                            else
                                insight = false;
                        }*/
                        insight = true;
                        break;
                    }
                    else
                    {
                        insight = false;
                        continue;
                    }
                }
                else
                {
                    continue;
                }
            }
        }
        if (deadNumber >= playerTeammate.Count)
        {
            insight = false;
            //Debug.Log("all dead");
        }
        if (insight)
        {
            direction = aimPos - currentPos;
            direction.Normalize();
            float targetAngle = Mathf.Atan2(-direction.x, direction.y) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, targetAngle), 1f);
        }
    }

    void Move()
    {
        int n;
        if(!insight)
        {
            if ((Time.time - timeCounter) > moveTime)
            {
                moveTime = Time.time;
                n = Random.Range(0, 13);
                velocity = patrolPosition[n].transform.position - transform.position;
                angle = Random.Range(-180, 180);
            }
            RandomRotate(angle);
            rb.MovePosition(transform.position + velocity.normalized * Time.deltaTime);
        }
    }

    void RandomRotate(float angle)
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, angle), 0.5f*Time.deltaTime);
    }
}
