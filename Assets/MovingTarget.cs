using UnityEngine;

public class MovingTarget : MonoBehaviour
{
	public GameObject particleEffectPrefab;  // Drag your Particle Effect Prefab here in the Inspector

    public float speed = 5.0f;
    public Vector3 boxSize = new Vector3(10, 0, 10); // Size of the box (Width, Height, Depth)
    private Vector3 initialPosition;
    private Vector3 nextPosition;
private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
        SetNextPosition();
    }

    // Update is called once per frame
    void Update()
    {
        // Move towards the next position
        transform.position = Vector3.MoveTowards(transform.position, nextPosition, speed * Time.deltaTime);

        // If the object has reached the next position, set a new random position within the box
        if (transform.position == nextPosition)
        {
            SetNextPosition();
        }
    }

    // Set a random next position within the boxed area
    void SetNextPosition()
    {
        nextPosition = new Vector3(
            Random.Range(initialPosition.x - boxSize.x / 2, initialPosition.x + boxSize.x / 2),
            initialPosition.y, // Assuming you don't want to move the object up or down
            Random.Range(initialPosition.z - boxSize.z / 2, initialPosition.z + boxSize.z / 2)
        );
    }
	
	void OnCollisionEnter(Collision collision)
    {
        // Check if the colliding object is tagged as 'Sphere'
if (collision.gameObject.name.Contains("SnowBall"))
        {
            // Instantiate the particle effect at the target's location
            Instantiate(particleEffectPrefab, transform.position, Quaternion.identity);
   //audioSource.Play();
             
            // Destroy the target GameObject
            Destroy(gameObject);
        }       


	    
    }
}
