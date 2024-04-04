using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingSound : MonoBehaviour
{
    public AudioSource audioSource; // The AudioSource component that will play the sound
    public float minimalWalkDistance = 1f; // The minimum distance the object must move before the sound is played

    private Vector3 previousPosition; // The position of the object in the previous frame
    private AudioHighPassFilter HighPassFilter;

    // Start is called before the first frame update
    void Start()
    {    
        previousPosition = transform.position; // Store the initial position of the object

    }

// Update is called once per frame
    void Update()
    {
        // Calculate the distance the object has moved since the last frame
        float moveDistance = Vector3.Distance(transform.position, previousPosition);

        // If the object has moved more than the minimum distance
        if (moveDistance >= minimalWalkDistance)
        {   
            audioSource.pitch = Random.Range(1.17f,1.35f) ; 
            audioSource.Play() ; // Play the sound
            previousPosition = transform.position ;  // Store the current position of the object for the next frame
        }
    }
}