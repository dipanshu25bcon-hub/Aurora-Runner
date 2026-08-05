using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float laneDistance = 6f;
    public float laneChangeSpeed = 10f;

    [Header("Jump")]
    public float jumpForce = 7f;

    private Rigidbody rb;
    private bool isGrounded = true;

    // 0 = Left, 1 = Center, 2 = Right
    private int currentLane = 1;

    private Vector3 targetPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        targetPosition = transform.position;
    }

    void Update()
    {
        // ==========================
        // LEFT / RIGHT LANE CHANGE
        // ==========================

        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            if (currentLane > 0)
                currentLane--;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            if (currentLane < 2)
                currentLane++;
        }

        // Calculate Target Position
        targetPosition = new Vector3(
            (currentLane - 1) * laneDistance,
            transform.position.y,
            transform.position.z
        );

        // Smooth Lane Movement
        transform.position = Vector3.Lerp(
            transform.position,
            targetPosition,
            laneChangeSpeed * Time.deltaTime
        );

        // ==========================
        // JUMP
        // ==========================

        bool pcJump = Input.GetKeyDown(KeyCode.Space);

        bool mobileJump = false;

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                mobileJump = true;
            }
        }

        if ((pcJump || mobileJump) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}