using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    NavMeshAgent _navMeshAgent;

    // Start is called before the first frame update
    void Start()
    {
        _navMeshAgent = this.GetComponent<NavMeshAgent>();

        if(_navMeshAgent == null){
            Debug.LogError("The nav mesh agent is component is not attached to " + gameObject.name);
        }
    }

    public void SetDestination(Vector3 _destination)
    {
        if(_destination != null){
            Vector3 targetVector = _destination;
            _navMeshAgent.SetDestination(targetVector);
        }
    }
}
