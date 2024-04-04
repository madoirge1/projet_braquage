using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustHighPassFilter : MonoBehaviour
{
    public float highPassCutoffFrequency = 500f; // Fréquence de coupure du filtre passe-haut
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        // Assurez-vous que le GameObject a un composant AudioHighPassFilter attaché
        if (audioSource.GetComponent<AudioHighPassFilter>() == null)
        {
            audioSource.gameObject.AddComponent<AudioHighPassFilter>();
        }
    }

    void Update()
    {
        // Récupérer le composant AudioHighPassFilter attaché à l'AudioSource
        AudioHighPassFilter highPassFilter = audioSource.GetComponent<AudioHighPassFilter>();
        
        // Si le composant existe
        if (highPassFilter != null)
        {
            // Modifier la fréquence de coupure du filtre passe-haut
            highPassFilter.cutoffFrequency = highPassCutoffFrequency;
        }
    }
}
