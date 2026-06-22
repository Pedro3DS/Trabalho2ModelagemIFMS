using System;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float sprintSpeed = 8f;
    [SerializeField] private float jumpHeight = 2f;
    [SerializeField] private float gravity = -9.8f;
    [SerializeField] private bool shouldFaceMoveDirection = false;
    [SerializeField] private Animator anim;
    [SerializeField] private ParticleSystem dust;

    private CharacterController controller;
    private Vector2 moveInput;
    private Vector3 velocity;
    private int doubleJumpCount = 0;
    private bool inJumpAction = false;

    private bool wasGrounded;
    private event Action OnLanded;
    private event Action OnLeftGround;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GetComponent<CharacterController>();
        // anim = GetComponent<Animator>();
    }

    public void OnMove(InputValue context)
    {
        moveInput = context.Get<Vector2>();
        Debug.Log($"Move Input: {moveInput}");
    }
    public void OnJump()
    {
        // Debug.Log($"Jumping {context.performed} - Is Grounded: {controller.isGrounded}");
        if (inJumpAction)
        {
            if (doubleJumpCount < 1)
            {
                doubleJumpCount++;
                if (GameObject.FindAnyObjectByType<AudioController>())
                    AudioController.Instance.JumpAudio();
                anim.SetTrigger("Flip");

                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }

        }
        if (controller.isGrounded)
        {
            inJumpAction = true;
            if (GameObject.FindAnyObjectByType<AudioController>())
                AudioController.Instance.JumpAudio();
            Debug.Log("We are supposed to jump");
            dust.Play();
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        CheckGround();

        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        forward.y = 0;
        right.y = 0;

        forward.Normalize();
        right.Normalize();

        Vector3 moveDirection = forward * moveInput.y + right * moveInput.x;
        float currentSpeed = speed;
        controller.Move(moveDirection * currentSpeed * Time.deltaTime);

        if (shouldFaceMoveDirection && moveDirection.sqrMagnitude > 0.001f)
        {
            Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, 10f * Time.deltaTime);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

    }

    public void CheckGround()
    {
        if (controller.isGrounded && !wasGrounded)
        {
            inJumpAction = false;
            doubleJumpCount = 0;
            if (GameObject.FindAnyObjectByType<AudioController>())
                AudioController.Instance.TouchGroundAudio();
            dust.Play();
            OnLanded?.Invoke();
        }

        else if (!controller.isGrounded && wasGrounded) OnLeftGround?.Invoke();
        wasGrounded = controller.isGrounded;
    }
}
