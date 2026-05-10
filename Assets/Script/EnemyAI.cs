using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform[] patrolPoints;
    public float speed = 2f;
    public float chaseDistance = 5f;

    private int currentPoint;
    private Transform player;

    void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");

        if (playerObj != null)
        {
            player = playerObj.transform;
        }
        else
        {
            Debug.LogError("Player tidak ditemukan!");
        }

        if (patrolPoints.Length == 0)
        {
            Debug.LogError("Patrol Point belum diisi!");
        }
    }

    void Update()
    {
        if (player == null) return;
        if (patrolPoints.Length == 0) return;

        float dist = Vector2.Distance(transform.position, player.position);

        if (dist < chaseDistance)
        {
            ChasePlayer();
        }
        else
        {
            Patrol();
        }
    }

    void Patrol()
    {
        Transform target = patrolPoints[currentPoint];

        transform.position = Vector2.MoveTowards(
            transform.position,
            target.position,
            speed * Time.deltaTime
        );

        if (Vector2.Distance(transform.position, target.position) < 0.2f)
        {
            currentPoint++;

            if (currentPoint >= patrolPoints.Length)
                currentPoint = 0;
        }
    }

    void ChasePlayer()
    {
        transform.position = Vector2.MoveTowards(
            transform.position,
            player.position,
            speed * Time.deltaTime
        );
    }
}