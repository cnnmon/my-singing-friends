using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonDisplay : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private AudioSource audioSource;
    public Person person;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        audioSource = this.GetComponent<AudioSource>();
        spriteRenderer.sprite = person.inactive;

        // Get background child object
        SpriteMask backgroundSpriteRenderer = this.transform.GetChild(0).GetComponent<SpriteMask>();
        backgroundSpriteRenderer.sprite = person.inactive;
    }

    // Play the audio clip
    public void PlaySound() {
        spriteRenderer.sprite = person.active;
        audioSource.clip = person.audioClip;
        if (!audioSource.isPlaying) {
            audioSource.Play();
        }
    }

    // Stop playing
    public void StopSound() {
        spriteRenderer.sprite = person.inactive;
        audioSource.Stop();
    }
}
