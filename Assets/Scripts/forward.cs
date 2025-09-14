using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forward : MonoBehaviour
{
    public float speed;
    public float sideSpeed;
    public float Jump_Force;

    public Transform center_pos;
    public Transform left_pos;
    public Transform right_pos;

    private int current_pos;

    private bool isPlay;

    public Animator player_animator;

    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
	isPlay = false;
        // Initialize Pos to the starting position (0)
        current_pos = 0;
	Physics.IgnoreLayerCollision(3, 6);
    }

    // Update is called once per frame
    void Update()
    {

	if(Input.GetMouseButtonDown(0))
	{
		isPlay = true;
		player_animator.SetFloat("is_run", 1);
	}

	if(isPlay)
{
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + speed * Time.deltaTime);

        if (current_pos == 0)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(center_pos.position.x, transform.position.y, transform.position.z), sideSpeed * Time.deltaTime);
        }
        else if (current_pos == 1)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(left_pos.position.x, transform.position.y, transform.position.z), sideSpeed * Time.deltaTime);
        }
        else if (current_pos == 2)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(right_pos.position.x, transform.position.y, transform.position.z), sideSpeed * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (current_pos == 0)
            {
                current_pos = 1;
            }
            else if (current_pos == 2)
            {
                current_pos = 0;
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (current_pos == 0)
            {
                current_pos = 2;
            }
            else if (current_pos == 1)
            {
                current_pos = 0;
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
           rb.AddForce(Vector3.up * Jump_Force, ForceMode.Impulse);
           StartCoroutine(Forword_Flip_Jump());
        }


    }
}
IEnumerator Forword_Flip_Jump()
{
    player_animator.SetFloat("is_jump", 1);
    yield return new WaitForSeconds(0.5f);
    player_animator.SetFloat("is_jump", 0); 
 }

}
