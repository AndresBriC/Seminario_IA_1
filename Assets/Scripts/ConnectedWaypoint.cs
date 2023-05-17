using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectedWaypoint : Waypoint
{
   [SerializeField] protected float _connectivityRadius = 50f;

    List<ConnectedWaypoint> _connections;

    public void Start()
    {
        // Grab all waypoints in scene
        GameObject[] allWaypoints = GameObject.FindGameObjectsWithTag("Waypoint");

        // Create a list of waypoints I can refer to later
        _connections = new List<ConnectedWaypoint>();

        // Check if they're a connected waypoint
        for(int i = 0; i < allWaypoints.Length; i++)
        {
            ConnectedWaypoint nextWaypoint = allWaypoints[i].GetComponent<ConnectedWaypoint>();

            // We found a waypoint
            if(nextWaypoint != null)
            {
                if(Vector3.Distance(this.transform.position, nextWaypoint.transform.position) <= _connectivityRadius && nextWaypoint != this)
                {
                    _connections.Add(nextWaypoint);
                }
            }
        }
    }

    public override void OnDrawGizmos()
    {
        // Draw a sphere at my position, with radius
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, debugDrawRadius);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _connectivityRadius);
    }

    public ConnectedWaypoint NextWaypoint(ConnectedWaypoint previousWaypoint)
    {
        // There are not enough waypoints
        if(_connections.Count == 0)
        {
            Debug.LogError("Insufficient waypoint count.");
            return null;
        }
        else if(_connections.Count == 1 && _connections.Contains(previousWaypoint))
        {
            // Only one waypoint and it's the previous one
            return previousWaypoint;
        }
        else // Otherwise, find a random one that isn't the previous one
        {
            ConnectedWaypoint nextWaypoint;
            int nextIndex = 0;

            do
            {
                nextIndex = UnityEngine.Random.Range(0, _connections.Count);
                nextWaypoint = _connections[nextIndex];
            } while (nextWaypoint == previousWaypoint);

            return nextWaypoint;

        }
    }

}
