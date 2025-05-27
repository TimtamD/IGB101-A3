using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TD_PlayerMovement : MonoBehaviour
{

    public Animator anim;

    public float rotSpeed = 10;

    private bool isSitting = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        ForwardMovement();

        Turning();

        Actions();

        Sitting();

    }

    private void ForwardMovement()
    {
        if (Input.GetKey("w"))
        {
            anim.SetBool("Walking", true);
            if (Input.GetKey(KeyCode.Space))
            {
                anim.SetBool("Jump", true);
            }
            else
            {
                anim.SetBool("Jump", false);
            }
            if (Input.GetKey(KeyCode.LeftShift))
            {
                anim.SetBool("Running", true);
                if (Input.GetKey(KeyCode.Space))
                {
                    anim.SetBool("RunJump", true);
                }
                else
                {
                    anim.SetBool("RunJump", false);
                }
            }
            else
            {
                anim.SetBool("Running", false);
            }
            if (Input.GetKey(KeyCode.Space))
            {
                anim.SetBool("Jump", true);
            }
        }
        else if (Input.GetKeyUp("w"))
        {
            anim.SetBool("Walking", false);
            anim.SetBool("Running", false);
            anim.SetBool("Jump", false);
        }

    }

    private void Turning()
    {
        if (Input.GetKey("a"))
        {
            transform.Rotate(0, -rotSpeed * 15 * Time.deltaTime, 0, Space.World);
            anim.SetBool("Turn Left", true);
        }
        else if (Input.GetKey("d"))
        {
            transform.Rotate(0, rotSpeed * 15 * Time.deltaTime, 0, Space.World);
            anim.SetBool("Turn Right", true);
        }
        else
        {
            anim.SetBool("Turn Left", false);
            anim.SetBool("Turn Right", false);
        }
    }

    private void Actions()
    {
        if (Input.GetKeyDown("e"))
        {
            anim.SetBool("Waving", true);
        }
        else if (Input.GetKeyUp("e"))
        {
            anim.SetBool("Waving", false);
        }
    }
    
    private void Sitting()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            isSitting = !isSitting; // Toggle sitting state
            anim.SetBool("Sitting", isSitting);
        }

        // Cancel sitting on any other key press
        if (isSitting && Input.anyKeyDown && !Input.GetKeyDown(KeyCode.LeftControl))
        {
            isSitting = false;
            anim.SetBool("Sitting", false);
        }
    }
}
