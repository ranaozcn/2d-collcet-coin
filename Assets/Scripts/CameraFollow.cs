using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float cameraSpeed;
    public Vector3 offset;
    void Update()
    {
        Vector3 targetPosition = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetPosition, cameraSpeed*Time.deltaTime);

    }
}
