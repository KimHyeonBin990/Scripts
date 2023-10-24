using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator animator;
    public float attackRange = 1f;
    public LayerMask enemyLayer;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z)) // 'Z' 키로 변경
        {
            Attack();
        }
    }

    void Attack()
    {
        animator.SetTrigger("Attack"); // 공격 애니메이션 실행

        // 주변에 있는 적들을 탐지하여 공격
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, attackRange, enemyLayer);

        foreach (Collider2D enemy in hitEnemies)
        {
            // 여기서 적에게 데미지를 입히는 코드를 작성합니다.
            // enemy.GetComponent<EnemyHealth>().TakeDamage(damage);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}