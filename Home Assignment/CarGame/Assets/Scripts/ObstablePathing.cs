using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstablePathing : MonoBehaviour
{
    //creates the list to store the waypoints
    [SerializeField] List<Transform> waypoints;
    [SerializeField] float moveSpeed = 2f;
    [SerializeField] WaveConfig waveConfig;

    //stores in which waypoint the obstacle is
    int waypointIndex = 0;


    // Start is called before the first frame update
    void Start()
    {
        //set start position of obstacle to Waypoint (0)
        transform.position = waypoints[waypointIndex].transform.position;

        //call the method GetWaypoints()
        waypoints = waveConfig.GetWaypoints();
    }

    // Update is called once per frame
    void Update()
    {
        MoveObstacle();
    }

    private void MoveObstacle()
    {
        if (waypointIndex <= waypoints.Count - 1)
        {
            var targetPosition = waypoints[waypointIndex].transform.position;	
            targetPosition.z = 0f;

            var movementThisFrame = moveSpeed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementThisFrame);

            //if the position is at the target waypoint
            if (transform.position == targetPosition)
            {
                //increment
                waypointIndex++;
            }
        }

        //if reached all waypoints
        else
        {
            Destroy(gameObject);
        }
    }


}
