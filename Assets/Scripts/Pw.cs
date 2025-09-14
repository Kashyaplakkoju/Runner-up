using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pw : MonoBehaviour
{
    public Transform VRPlayer;
    public float tiltThreshold = 25f;
    private CharacterController cc;
    public float speed = 3.0f;
    private bool moveLeft;
    private bool moveRight;

    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Check if VR player is tilting left
        if (VRPlayer.eulerAngles.z > tiltThreshold && VRPlayer.eulerAngles.z < 180.0f)
        {
            moveLeft = true;
            moveRight = false;
        }
        // Check if VR player is tilting right
        else if (VRPlayer.eulerAngles.z < 360.0f - tiltThreshold && VRPlayer.eulerAngles.z > 180.0f)
        {
            moveLeft = false;
            moveRight = true;
        }
        else
        {
            moveLeft = false;
            moveRight = false;
        }

        // Move left or right based on VR tilt
        if (moveLeft)
        {
            Vector3 leftDirection = VRPlayer.TransformDirection(Vector3.left);
            cc.SimpleMove(leftDirection * speed);
        }
        else if (moveRight)
        {
            Vector3 rightDirection = VRPlayer.TransformDirection(Vector3.right);
            cc.SimpleMove(rightDirection * speed);
        }
    }
}
