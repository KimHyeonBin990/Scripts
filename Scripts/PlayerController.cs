using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 60f;    // 이동 속도
    public float jumpForce = 50f;   // 점프 힘

    
    bool isFacingRight = true;

    private bool isGrounded = true; // 플레이어가 땅에 있는지 여부를 나타내는 변수

    //public float minX; // X 좌표의 최소값
    //public float maxX; // X 좌표의 최대값
    //public float minY; // Y 좌표의 최소값
    //public float maxY; // Y 좌표의 최대값

    void Update()
    {
        // 좌우 이동
        float moveInput = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(moveInput * moveSpeed * Time.deltaTime, 0, 0);
        transform.Translate(movement);

        // 방향 전환
        if (moveInput > 0 && !isFacingRight)
        {
            Flip();
        }
        else if (moveInput < 0 && isFacingRight)
        {
            Flip();
        }

        
        {
            if (Input.GetKey(KeyCode.Space))
            {
                Jump();
            }
        }


        // 플레이어 위치를 제한
        //float clampedX = Mathf.Clamp(transform.position.x, minX, maxX);
        //float clampedY = Mathf.Clamp(transform.position.y, minY, maxY);
        //transform.position = new Vector3(clampedX, clampedY, transform.position.z);
    }

    void Jump()
    {
        isGrounded = false; // 점프 시 땅에서 떨어졌다고 설정

        GetComponent<Rigidbody2D>().velocity = new Vector2(0, jumpForce);

        // 위로 향하는 힘을 가해 플레이어를 점프시킵니다.
        //transform.position += Vector3.up * jumpForce * Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}