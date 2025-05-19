using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 velocity;
    private float xRotation = 0f;
    public Transform playerCamera;
    public float mouseSensitivity = 2f;
    public float verticalLookLimit = 80f;
    public float moveSpeed = 3f;
    public float sprintSpeed = 8f;
    public KeyCode sprintKey = KeyCode.LeftShift;
    private float originalSpeed;
    [SerializeField] private bool isMoving = false;
    public AudioSource footstep;
    [SerializeField] private float stamina = 50f;
    public bool hasKey = false;
    public GameObject keyInd;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        originalSpeed = moveSpeed;
    }

    void Update()
    {
        HandleMovement();
        HandleMouseLook();
    }

    void HandleMovement()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        
        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        float currentSpeed;
        Debug.Log(move);

        if (move != Vector3.zero)
        {
            isMoving = true;
            if (isMoving)
            {
                if (!footstep.isPlaying)
                    footstep.Play();
            }
            else
            {
                if (footstep.isPlaying)
                {
                    footstep.Stop();
                    isMoving = false;
                }
            }
        }

        if (Input.GetKey(sprintKey))
        {
            currentSpeed = sprintSpeed;
            while (stamina > 0)
            {
                stamina--;
            }
        }
        else
        {
            currentSpeed = originalSpeed;
            while (stamina < 50)
            {
                stamina++;
            }
        }

        controller.Move(move * currentSpeed * Time.deltaTime);
        controller.Move(velocity * Time.deltaTime);
    }

    void HandleMouseLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -verticalLookLimit, verticalLookLimit);

        playerCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Key")
        {
            hasKey = true;
            other.gameObject.SetActive(false);
            keyInd.SetActive(true);
        }
    }
}
