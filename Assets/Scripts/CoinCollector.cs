using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    public AudioClip collectSound; // Assign the collect sound in the Unity Editor

    private AudioSource audioSource;

    private void Start()
    {
        // Get the AudioSource component attached to this GameObject
        audioSource = GetComponent<AudioSource>();

        // Assign the collect sound to the AudioSource component
        audioSource.clip = collectSound;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            Debug.Log("Coin collected!");
            
            // Play the collect sound
            audioSource.Play();

            // Destroy the coin object
            Destroy(collision.gameObject);
        }
    }
}
