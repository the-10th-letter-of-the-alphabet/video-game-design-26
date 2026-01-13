using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform[] patrolPoints;
    public float moveSpeed;
    public int patrolDestination;

    void Update()
    {    
        transform.position = Vector3.MoveTowards(transform.position, patrolPoints[patrolDestination].position, moveSpeed * Time.deltaTime);

        if (transform.position == patrolPoints[patrolDestination].position)
        {
            patrolDestination = (patrolDestination + 1) % patrolPoints.Length;
        }
    }
}
