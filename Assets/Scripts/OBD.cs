using UnityEngine;

public class OBD : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // Destroy the collided object
        Destroy(collision.gameObject);
    }
}
