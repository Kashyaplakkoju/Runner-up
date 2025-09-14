using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TTP : MonoBehaviour
{
    public TextMeshProUGUI tapToPlayText;

    void Start()
    {
        // Ensure the tapToPlayText is enabled initially
        tapToPlayText.gameObject.SetActive(true);
    }

    void Update()
    {
        // Check for touch input
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            // Hide the tapToPlayText when a touch is detected
            tapToPlayText.gameObject.SetActive(false);
        }
    }
}
