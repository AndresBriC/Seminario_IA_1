using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastClickDetection : MonoBehaviour
{

    private Camera mainCamera;

    public LayerMask floorLayer;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Check if ray hits something
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, floorLayer))
            {
                // Check if the hit object has a collider
                if (hit.collider != null)
                {
                    // Get the point where the ray hits the collider
                    Vector3 targetPoint = hit.point;

                    // Pass the target point to the player movement script
                    PlayerMovement playerMovement = GetComponent<PlayerMovement>();
                    if (playerMovement != null)
                    {
                        playerMovement.SetDestination(targetPoint);
                        
                    }
                }
            }
        }
    }
}
