using UnityEngine;

public class CameraController : MonoBehaviour
{
    //Camera Follows Player
    [SerializeField] Transform followTarget;

    //Adjust Rotation & Camera Angles
    [SerializeField] float rotationSpeed = 2f;
    [SerializeField] float distance = 5;

    //Adjust Max & Min Points of Verticle Rotation
    [SerializeField] float minVerticalAngle = -45;
    [SerializeField] float maxVerticalAngle = 45;

    // 
    [SerializeField] Vector2 framingOffset;

    //Invert Controls 
    [SerializeField] bool invertX;
    [SerializeField] bool invertY;

    //Rotation Variables
    float rotationX;
    float rotationY;

    //Invert Variables
    float invertXVal;
    float invertYVal;

    private void Start()
    {
        //Cursor Mechanics - Hide, Lock
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

    }

    private void Update()
    {
        //Invert Math
        invertXVal = (invertX) ? -1 : 1;
        invertYVal = (invertY) ? -1 : 1;

        //Camera Rotation Math
        rotationY += Input.GetAxis("Mouse X") * invertXVal * rotationSpeed;
        rotationX = Mathf.Clamp(rotationX, minVerticalAngle, maxVerticalAngle);
        rotationX += Input.GetAxis("Mouse Y") * invertYVal * rotationSpeed;

        var targetRotation = Quaternion.Euler(rotationX, rotationY, 0);

        var focusPosition = followTarget.position + new Vector3(framingOffset.x, framingOffset.y);

        transform.position = focusPosition - targetRotation * new Vector3(0, 0, distance);
        transform.rotation = targetRotation;
    }

    public Quaternion PlanarRotation => Quaternion.Euler(0, rotationY, 0);
}
