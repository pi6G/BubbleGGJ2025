using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrossyEnemy : MonoBehaviour
{
    [SerializeField] private List<GameObject> grossBalls;

    [SerializeField] private float updateTime = 5f;
    private float timer = 0;

    [SerializeField] private Animator enemyAnimator;

    private Transform player;

    private UnityEngine.AI.NavMeshAgent agent;

    [SerializeField] private float attackDistance;
    [SerializeField] private float attackDamage;

    [SerializeField] private float damageCooldown;
    private bool attackOnCD;
    private float atkTimer;

    private void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        player = GameObject.FindWithTag("Player").transform;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > updateTime)
        {
            agent.SetDestination(player.position);
        }

        Vector3 difference = transform.position - player.position;
        if (difference.magnitude < attackDistance && atkTimer < 0f)
        {
            attackOnCD = true;
            Attack();
            atkTimer = damageCooldown;
        }

        atkTimer -= Time.deltaTime;
    }

    private void Attack()
    {
        player.GetComponent<LifeManager>().TakeDamage(attackDamage);

    }

    public void EliminateBall(GameObject grossBall)
    {
        grossBalls.Remove(grossBall);
        Destroy(grossBall, 0.1f);

        if (grossBalls.Count == 0)
        {
            Die();
        }
    }

    private void Die()
    {
        agent.Stop();
        enemyAnimator.Play("Death");
        GetComponentInParent<GrossyEnemyHolder>().EliminateEnemy(this.gameObject);
    }

}
