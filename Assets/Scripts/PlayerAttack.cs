using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float attackCooldown;
    private PlayerMovement playerMovement;
    private float cooldownTimer = 30f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && cooldownTimer > attackCooldown && playerMovement.canAttack())
            Attack();

        cooldownTimer += Time.deltaTime;
    }

    private void Attack()
    {
        cooldownTimer = 0;
    }
}
