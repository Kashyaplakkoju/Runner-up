using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam_script : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        if (player == null)
        {
            Debug.LogError("Player transform is not assigned to the camera script!");
        }
    }

    // LateUpdate is called once per frame, after Update
    void LateUpdate()
    {
        if (player != null)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, player.transform.position.z - 5f);
        }
    }
}
