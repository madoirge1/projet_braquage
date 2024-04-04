using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RugWalk : MonoBehaviour
{
    public AudioClip[] defaultFootsteps;
    public AudioClip[] floorFootsteps;
    public AudioClip[] highpassFootsteps;

    private AudioSource audioSource;
    private bool isMoving = false;
    private float raycastDistance = 0.1f;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.down, out hit, raycastDistance))
        {
            string surfaceTag = hit.collider.tag;

            Debug.Log("Detected surface: " + surfaceTag); // Debug log to display detected surface

            if (!audioSource.isPlaying && isMoving) // Check if no footstep is currently playing and the player is moving
            {
                switch (surfaceTag)
                {
                    case "Floor":
                        PlayFootstepSound(highpassFootsteps);
                        break;
                    //case "Wood":
                      //  PlayFootstepSound(woodFootsteps);
                    //case "Tiles":
                       // PlayFootstepSound(tileFootsteps);
                       // break;
                    default:
                        break;
                }
            }
        }
        else
        {
            Debug.Log("No surface detected!"); // Debug log when no surface is detected
        }

        // Check for player movement using Unity's input system
       // float movementInput = Input.GetAxisRaw("Horizontal") + Input.GetAxisRaw("Vertical");
       // isMoving = movementInput != 0f; // Set isMoving to true if movementInput is not zero

       // Debug.Log("Is moving: " + isMoving); // Debug log to show whether the player is moving
    }

    private void PlayFootstepSound(AudioClip[] footstepSounds)
    {
        if (footstepSounds.Length > 0)
        {
            AudioClip footstepSound = footstepSounds[Random.Range(0, footstepSounds.Length)];
            audioSource.PlayOneShot(footstepSound);
        }
    }
}