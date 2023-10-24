using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 60f;    // �̵� �ӵ�
    public float jumpForce = 50f;   // ���� ��

    
    bool isFacingRight = true;

    private bool isGrounded = true; // �÷��̾ ���� �ִ��� ���θ� ��Ÿ���� ����

    //public float minX; // X ��ǥ�� �ּҰ�
    //public float maxX; // X ��ǥ�� �ִ밪
    //public float minY; // Y ��ǥ�� �ּҰ�
    //public float maxY; // Y ��ǥ�� �ִ밪

    void Update()
    {
        // �¿� �̵�
        float moveInput = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(moveInput * moveSpeed * Time.deltaTime, 0, 0);
        transform.Translate(movement);

        // ���� ��ȯ
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


        // �÷��̾� ��ġ�� ����
        //float clampedX = Mathf.Clamp(transform.position.x, minX, maxX);
        //float clampedY = Mathf.Clamp(transform.position.y, minY, maxY);
        //transform.position = new Vector3(clampedX, clampedY, transform.position.z);
    }

    void Jump()
    {
        isGrounded = false; // ���� �� ������ �������ٰ� ����

        GetComponent<Rigidbody2D>().velocity = new Vector2(0, jumpForce);

        // ���� ���ϴ� ���� ���� �÷��̾ ������ŵ�ϴ�.
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