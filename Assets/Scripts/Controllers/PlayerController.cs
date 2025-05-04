using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Movement Variable
    [SerializeField] float moveSpeed = 5f;

    //Camera Lock
    CameraController cameraController;

    private void Awake()
    {
        Camera.main.GetComponent<CameraController>();
    }

    void Update()
    {
        //Player Movement Variables
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        //Player Movement
        var moveInput = (new Vector3(h, 0, v)).normalized;

        var moveDir = cameraController.PlanarRotation * moveInput;

        transform.position += moveDir * moveSpeed * Time.deltaTime;
    }
} 
