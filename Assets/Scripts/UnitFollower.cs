using UnityEngine;

public class UnitFollower : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public float moveSpeed = 5f; // Speed at which the unit moves
    public float formationSpacing = 1f; // Spacing between units in the formation

    private Vector3 targetPosition; // Target position for the unit to move towards

    private void Start()
    {
        // Calculate the initial target position based on the unit's position and player's position
        targetPosition = transform.position;
    }

    private void Update()
    {
        // Calculate the direction towards the player
        Vector3 direction = player.position - transform.position;
        direction.Normalize();

        // Calculate the target position based on the formation spacing
        targetPosition = player.position - direction * formationSpacing;

        // Move the unit towards the target position
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }
}
