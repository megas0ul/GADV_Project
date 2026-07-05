using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth;
    private float currentHealth;
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float _damage)
    {
        //Makes sure that health does not go below 0 and over maximum health
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, maxHealth);

        if (currentHealth > 0)
        {
            // player loses health
        }
        else
        {
            //Game Over
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
