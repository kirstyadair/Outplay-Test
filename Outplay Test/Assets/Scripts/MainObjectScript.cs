using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainObjectScript : MonoBehaviour
{
    [Header("Points")]
    public Vector3[] points;
    [Header("Sphere Stats")]
    public float speed;

    bool destroying = false;
    int currentPointIndex = 0;
    Vector3 desiredVelocity;

    void Update()
    {
        // If the object is not in the process of being destroyed
        if (!destroying)
        {
            // Find the desired direction to move
            desiredVelocity = Vector3.Normalize(points[currentPointIndex] - transform.position) * speed;
            transform.position += desiredVelocity;

            // Check the distance between the ball and the point
            if (Vector3.Distance(transform.position, points[currentPointIndex]) < 0.5f)
            {
                // If at the final point
                if (currentPointIndex == points.Length - 1)
                {
                    StartCoroutine(DestroyObject());
                }
                else
                {
                    // If it's close enough to the point, start heading to the next point
                    currentPointIndex++;
                }
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Upon collision with an obstacle, destroy the object
        if (other.tag == "Obstacle") StartCoroutine(DestroyObject());
    }

    IEnumerator DestroyObject()
    {
        destroying = true;
        
        // Hide the object and allow the particle effect to play
        GetComponent<MeshRenderer>().enabled = false;
        GetComponentInChildren<ParticleSystem>().Play();
        // Play audio
        GetComponent<AudioSource>().Play();
        // Wait for .5 seconds
        yield return new WaitForSeconds(0.5f);
        // Delete the gameObject
        Destroy(this.gameObject);
    }
}
