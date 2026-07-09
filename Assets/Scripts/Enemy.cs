using UnityEngine;

public class Enemy : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        GetComponent<BoxCollider2D>();
        //GetComponent<EnemyHealth>();
    }
    // Update is called once per frame
    private void Update()
    {
        
    }
}
