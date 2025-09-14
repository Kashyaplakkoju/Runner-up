using System.Collections;
using UnityEngine;

public class VRF : MonoBehaviour
{
    public float speed;
    public float sideSpeed;
    public float jumpThreshold; // Angle threshold for jump set it to 0.5
    public float jumpForce;

    public Transform center_pos;
    public Transform left_pos;
    public Transform right_pos;

    private int current_pos;
    private bool isPlay;
    private Animator player_animator;
    private Rigidbody rb;

    void Start()
    {
        isPlay = false;
        current_pos = 0;
        player_animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        Physics.IgnoreLayerCollision(3, 6);

        // Ensure accelerometer is enabled
        Input.gyro.enabled = true;
    }

    void Update()
    {
        if (Input.acceleration.z < -0.9f && !isPlay)
        {
            isPlay = true;
            player_animator.SetBool("is_run", true);
        }

        if (isPlay)
        {
            // Movement logic based on accelerometer
            float tilt = Input.acceleration.x;

            // Update position based on tilt
            Vector3 newPos = transform.position + new Vector3(tilt * sideSpeed * Time.deltaTime, 0, speed * Time.deltaTime);
            transform.position = Vector3.Lerp(transform.position, newPos, Time.deltaTime * 10); // Smooth movement using Lerp

            // Switch lanes based on tilt direction
            if (tilt > 0.1f && current_pos != 2)
            {
                current_pos++;
            }
            else if (tilt < -0.1f && current_pos != 0)
            {
                current_pos--;
            }

            // Jump logic based on accelerometer tilt
            if (Input.acceleration.y > jumpThreshold)
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                StartCoroutine(Forword_Flip_Jump());
            }
        }
        else
        {
            player_animator.SetBool("is_run", false);
        }
    }

    IEnumerator Forword_Flip_Jump()
    {
        player_animator.SetBool("is_jump", true);
        yield return new WaitForSeconds(0.5f);
        player_animator.SetBool("is_jump", false);
    }
}
