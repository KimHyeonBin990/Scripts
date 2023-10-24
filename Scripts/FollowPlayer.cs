using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player; // 따라다닐 플레이어의 Transform 컴포넌트

    void Update()
    {
        // 1. 플레이어 따라다니기
        Vector3 targetPosition = new Vector3(player.position.x, player.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * 5f);

        // 2. 배경 밖으로 나가지 않게 하기
        //Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        //pos.x = Mathf.Clamp01(pos.x);
        //pos.y = Mathf.Clamp01(pos.y);
        //transform.position = Camera.main.ViewportToWorldPoint(pos);
    }
}