using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Main Variables")]
    [SerializeField] float walkSpeed = 6f;
    [SerializeField] float runSpeed = 8f;
    [SerializeField] float gravity = -9.81f;
    float currentSpeed;

    [Space]

    [Header("Grounding")]
    [SerializeField] Transform groundCheck;
    [SerializeField] float groundCheckRadius = 0.4f;
    [SerializeField] LayerMask groundMask;

    CharacterController controller;
    Vector3 velocity;

    bool isGrounded;
    bool isRunning;

    void Awake () {
        controller = GetComponent<CharacterController>();
    }

    void Start () {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update () {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundMask);

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        if (velocity.y < 0f && isGrounded) {
            velocity.y = -2f;
        }

        Vector3 movement = transform.forward * vertical + transform.right * horizontal;
        movement.Normalize();

        velocity.y += gravity * 2f * Time.deltaTime;

        if (Input.GetKey(KeyCode.LeftShift) && isGrounded && (horizontal != 0 || vertical != 0)) {
            isRunning = true;
        }
        else {
            isRunning = false;
        }

        controller.Move(movement * (isRunning ? runSpeed : walkSpeed) * Time.deltaTime);
        controller.Move(velocity * Time.deltaTime);
    }
}
