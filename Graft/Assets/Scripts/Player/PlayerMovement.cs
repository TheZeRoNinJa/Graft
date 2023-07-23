using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;

    public float groundDrag;

    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;
    

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    [Header("Interaction")]
    [SerializeField] Vector3 interactionRayPoint;
    [SerializeField] float interactionDistance;
    [SerializeField] LayerMask interactionLayer;
    Interactable currentInteractable;
    RaycastHit hitInfo;

    [Header("Torch Stuff")]
    [SerializeField] Animator torchAnimator;

    [Header("Sounds")]
    [SerializeField] AudioSource footstepSound;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {

        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

        PlayerInput();
        SpeedControl();
        
        if(grounded)
        {
            rb.drag = groundDrag;
        }
        else
        {
            rb.drag = 0;
        }
    }

    private void FixedUpdate()
    {
        MovePlayer();

    }

    private void PlayerInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if(horizontalInput == 0 && verticalInput == 0)
        {
            footstepSound.Stop();
        }

        
        //if (Input.GetKeyDown(KeyCode.E))
        //{
        //    Physics.Raycast(Camera.main.transform.position.normalized, Camera.main.transform.forward, out hitInfo, 100f);
        //    Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * 100f, Color.red);
        //    if (hitInfo.transform.tag == "NPC")
        //    {
        //        hitInfo.transform.gameObject.GetComponent<DialogueScript>().Interact();
        //        Debug.Log(hitInfo.transform.name);
        //    }
        //}
        
    }

    private void MovePlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        rb.AddForce(moveDirection.normalized * moveSpeed * 10);

        if (rb.velocity.x != 0 || rb.velocity.z != 0)
        {
            torchAnimator.SetBool("playerIsMoving", true);
            if (!footstepSound.isPlaying)
            {
                footstepSound.Play();
            }
        }
        else
        {
            torchAnimator.SetBool("playerIsMoving", false);
            
        }
    }

    private void SpeedControl()
    {
        Vector3 flatVelocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if (flatVelocity.magnitude > moveSpeed)
        {
            Vector3 limitedVelocity = flatVelocity.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVelocity.x, rb.velocity.y, limitedVelocity.z);
        }
    }

    //private void HandleInteractionCheck()
    //{
    //    if(Physics.Raycast(Camera.main.ViewportPointToRay(interactionRayPoint), out RaycastHit hit, interactionDistance))
    //    {
    //        if(hit.collider.gameObject.layer == 9 && currentInteractable == null) 
    //        {
    //            hit.collider.TryGetComponent(out currentInteractable);

    //            if (currentInteractable)
    //            {
    //                currentInteractable.OnFocus();
    //            }
    //        }
    //    }
    //    else if (currentInteractable)
    //    {
    //        currentInteractable.OnLoseFocus();
    //        currentInteractable = null;
    //    }
    //}

    //private void HandleInteractionInput()
    //{
    //    if(Input.GetKeyDown(KeyCode.E) && currentInteractable != null && Physics.Raycast(Camera.main.ViewportPointToRay(interactionRayPoint), out RaycastHit hit, interactionDistance, interactionLayer))
    //    {
    //        currentInteractable.OnInteract();
    //    }
    //}
}
