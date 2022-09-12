using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] Rigidbody2D playerRb;
    [SerializeField] Animator playerAnimator;
    [SerializeField] float speed = 10f;
    [SerializeField] float sprintSpeed = 2f;
    [SerializeField] GameObject torchLight;

    public Vector3 targetPosition;
    public Quaternion lookRotation;
    public bool isControllable = true;


    float horizontalInput;
    float verticalInput;
    bool isRunning;
    Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        playerAnimator.SetFloat("Horizontal", horizontalInput);
        playerAnimator.SetFloat("Vertical", verticalInput);
        if (Mathf.Abs(horizontalInput) > 0.1f || Mathf.Abs(verticalInput) > 0.1f)
        {
            playerAnimator.SetFloat("MemoHorizontal", horizontalInput);
            playerAnimator.SetFloat("MemoVertical", verticalInput);
        }
        playerAnimator.SetFloat("Vertical", verticalInput);
        if (horizontalInput != 0 || verticalInput != 0) isRunning = true;
        else isRunning = false;
        playerAnimator.SetBool("IsRunning", isRunning);

        if (Input.GetButton("Sprint"))
        {
            velocity = speed * sprintSpeed * new Vector2(horizontalInput, verticalInput).normalized;
            playerAnimator.SetBool("Sprint", true);
        }
        else
        {
            velocity = speed * new Vector2(horizontalInput, verticalInput).normalized;
            playerAnimator.SetBool("Sprint", false);
        }

        if (Input.GetButtonDown("Roll"))
        {
            playerAnimator.SetBool("Roll", true);
        }

        if (isControllable)
        {

            if (velocity.magnitude != 0f)
            {
                torchLight.transform.up = velocity.normalized;
            }
        }
    }

    private void FixedUpdate()
    {
        playerRb.velocity = velocity;
    }
}
