using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI scoreUI;

    // Update is called once per frame
    void Update()
    {
        // Update the score UI text
        scoreUI.text = score.ToString();
    }

    private void OnCollisionEnter(Collision collision)
    {

        // Check if the collider's GameObject has the "Coin" tag
        if (collision.gameObject.CompareTag("Coin"))
        {
            // Increment the score
            score++;
        }
    }
}
