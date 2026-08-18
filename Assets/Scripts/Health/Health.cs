using Unity.VisualScripting;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header ("Health")]
    [SerializeField]private float maxHealth;
    public float currentHealth { get; private set; }
    private bool dead;

    [Header ("Components")]
    [SerializeField] private Behaviour[] components;
    private void Awake()
    {
        currentHealth = maxHealth;
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
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
            TakeDamage(1);
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
