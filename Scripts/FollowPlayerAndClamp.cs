using UnityEngine;

public class FollowPlayerAndClamp : MonoBehaviour
{
    public Transform player;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    void Update()
    {
        if (player != null)
        {
            Vector3 targetPosition = new Vector3(player.position.x, player.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * 5f);

            Vector3 clampedPosition = transform.position;
            clampedPosition.x = Mathf.Clamp(clampedPosition.x, minX, maxX);
            clampedPosition.y = Mathf.Clamp(clampedPosition.y, minY, maxY);
            transform.position = clampedPosition;
        }
    }
}
