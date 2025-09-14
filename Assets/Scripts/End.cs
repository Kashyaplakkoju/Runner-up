using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Ended"); // Print "Game Ended" to the console

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
