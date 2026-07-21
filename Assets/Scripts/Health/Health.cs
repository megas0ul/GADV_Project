using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]private float maxHealth;
    public float currentHealth { get; private set; }
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
        if(Input.GetKeyDown(KeyCode.E))
            TakeDamage(1);
    }
}
