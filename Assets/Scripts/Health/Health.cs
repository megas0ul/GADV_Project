using UnityEngine;

public class Health : MonoBehaviour
{
    [Header ("Health")]
    [SerializeField]private float maxHealth;
    [SerializeField]private float startingHealth = 5f;
    public float currentHealth { get; private set; }
    private bool dead;

    [Header ("Components")]
    [SerializeField] private Behaviour[] components;
    private void Awake()
    {
        currentHealth = startingHealth;
    }

    public void TakeDamage(float _damage)
    {
        //Makes sure that health does not go below 0 and over maximum health
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, maxHealth);

        if (currentHealth > 0)
        {
            // Hurt animation TBD
        }
        else
        {
            if (!dead)
            {
                //Deactivates all attached components
                foreach(Behaviour component in components)
                    component.enabled = false;
                Deactivate();
                dead = true;
            }
        }
    }

    // Update is called once per frame
    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }
    public void Respawn()
    {
        dead = false;
        AddHealth(startingHealth);
        foreach(Behaviour component in components)
            component.enabled = true;

    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
