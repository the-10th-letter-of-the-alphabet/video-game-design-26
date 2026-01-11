using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public Transform cameraHolder;
    public Vector3 offset = new Vector3(0f, 1f, -10f);
    [Range(0f, 1f)] public float smoothSpeed = 0.125f;

    // Update is called once per frame
    void Update()
    {
        Vector3 desiredPosition = cameraHolder.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
