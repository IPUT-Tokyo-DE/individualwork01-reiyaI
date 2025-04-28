using UnityEngine;

public class SimpleSoundTest : MonoBehaviour
{
    public AudioClip clip;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.PlayOneShot(clip);
    }
}
