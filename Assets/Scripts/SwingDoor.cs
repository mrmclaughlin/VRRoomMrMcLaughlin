using UnityEngine;

public class DoorHandle : MonoBehaviour
{
    public GameObject door; // Reference to the door GameObject
    public float swingForce = 10.0f; // The force with which the door will swing open
    private Rigidbody doorRb;
    private bool isPlayerNearby = false; // Flag to check if the player is near the handle

    void Start()
    {
        doorRb = door.GetComponent<Rigidbody>(); // Get the Rigidbody from the door GameObject
    }

    void Update()
    {
        // If the player is nearby and presses the 'E' key, swing the door open
        if (isPlayerNearby )
        {
            Vector3 swingDirection = door.transform.forward * -1;
            doorRb.AddForce(swingDirection * swingForce, ForceMode.Impulse);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Assuming the player GameObject has the tag "Player"
        if (other.CompareTag("XR Rig"))
        {
            isPlayerNearby = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("XR Rig"))
        {
            isPlayerNearby = false;
        }
    }
}
