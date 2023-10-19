using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snowBallMove : MonoBehaviour
{
	public GameObject particleEffectPrefab;
	private Transform randomPosition;
	private Transform TransformBall;
	public float areaRadius = 10f;      // Radius of the pile
public Transform target; // Drag the destination point here in the Inspector
    public float forceAmount = .005f; // Set the force amount to control the speed

    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
		
         Vector3 randomPosition = new Vector3(
                Random.Range(-areaRadius, areaRadius),
                Random.Range(0, areaRadius),
                Random.Range(-areaRadius, areaRadius));
		TransformBall = GetComponent<Transform>();
		TransformBall.position = randomPosition;
		rb = GetComponent<Rigidbody>();		
    }

void FixedUpdate()
    {
        // Calculate the direction vector from the sphere to the target point
        Vector3 direction = (target.position - transform.position).normalized;

        // Apply force in that direction
        rb.AddForce(direction * forceAmount);
    }
	
	
	void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("Target") || collision.gameObject.name.Contains("Tree") || collision.gameObject.name.Contains("Spruce")|| collision.gameObject.name.Contains("Pine"))
        {
            // Instantiate the particle effect at the target's location
            Instantiate(particleEffectPrefab, transform.position, Quaternion.identity);

            // Destroy the target GameObject
            Destroy(gameObject);
        }
		
	}



    // Update is called once per frame
    void Update()
    {
        
    }
}
