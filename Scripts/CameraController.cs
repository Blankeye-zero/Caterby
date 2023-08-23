using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;// The target object to follow (e.g., the player)
    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    public Vector3 minBounds; // Minimum boundaries
    public Vector3 maxBounds; // Maximum boundaries

    private void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        // Clamp the camera position within the bounds
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, minBounds.x, maxBounds.x),
            Mathf.Clamp(transform.position.y, minBounds.y, maxBounds.y),
            Mathf.Clamp(transform.position.z, minBounds.z, maxBounds.z)
        );
    }
}
