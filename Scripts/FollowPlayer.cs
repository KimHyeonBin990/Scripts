using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player; // ����ٴ� �÷��̾��� Transform ������Ʈ

    void Update()
    {
        // 1. �÷��̾� ����ٴϱ�
        Vector3 targetPosition = new Vector3(player.position.x, player.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * 5f);

        // 2. ��� ������ ������ �ʰ� �ϱ�
        //Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        //pos.x = Mathf.Clamp01(pos.x);
        //pos.y = Mathf.Clamp01(pos.y);
        //transform.position = Camera.main.ViewportToWorldPoint(pos);
    }
}