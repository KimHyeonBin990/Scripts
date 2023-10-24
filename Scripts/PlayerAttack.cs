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
        if (Input.GetKeyDown(KeyCode.Z)) // 'Z' Ű�� ����
        {
            Attack();
        }
    }

    void Attack()
    {
        animator.SetTrigger("Attack"); // ���� �ִϸ��̼� ����

        // �ֺ��� �ִ� ������ Ž���Ͽ� ����
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, attackRange, enemyLayer);

        foreach (Collider2D enemy in hitEnemies)
        {
            // ���⼭ ������ �������� ������ �ڵ带 �ۼ��մϴ�.
            // enemy.GetComponent<EnemyHealth>().TakeDamage(damage);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}