using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;
    private Transform target;
    private int waypointIndex = 0;
    private Vector3 startPosition;

    void Start()
    {
        target = Waypoint.points[0];
        startPosition = transform.position;
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWaypoint();
        }
    }


    private void GetNextWaypoint()
    {
        if (waypointIndex >= Waypoint.points.Length - 1)
        {
            Restart();
            return;
        }
        waypointIndex++;
        target = Waypoint.points[waypointIndex];
    }

    private void Restart()
    {
        transform.position = startPosition;
        waypointIndex = 0;
        target = Waypoint.points[waypointIndex];
    }

}
