using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float attackCooldown;
    public Transform projectilePoint;
    public GameObject[] projectiles;
    private PlayerMovement playerMovement;
    private float cooldownTimer = Mathf.Infinity; //Any big number can be used for this
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    private void Update()
    {
        //Checks if theres a cooldown and player is grounded before throwing a projectile
        if (Input.GetKey(KeyCode.Mouse0) && cooldownTimer > attackCooldown && playerMovement.canAttack())
            Attack();

        cooldownTimer += Time.deltaTime;
    }

    private void Attack()
    {
        cooldownTimer = 0;
        
        projectiles[FindProjectile()].transform.position = projectilePoint.position; //Reset each projectile that is shot
        projectiles[FindProjectile()].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x)); 
        //Gets reference to the projectile script]
    }

    private int FindProjectile()
    {
        for (int i = 0; i < projectiles.Length; i++) //loop through every fireball
        {
            if (!projectiles[i].activeInHierarchy) //Check if projectile is active 
                return i;
        }
        return 0; //default
    }
}
