using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float projectileSpeed;
    private float direction;
    private bool hit;

    private BoxCollider2D boxCollider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (hit) return;
        float movementSpeed = projectileSpeed * Time.deltaTime * direction;
        transform.Translate(movementSpeed, 0, 0); //Makes the Projectile fly in a straight line
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {//Returns hit = true when colliding with object
        hit = true;
        boxCollider.enabled = false;
        gameObject.SetActive(false);
    }

    public void SetDirection(float _direction)
    {
        direction = _direction;
        gameObject.SetActive(true);
        hit = false;
        boxCollider.enabled = true;

        float localScaleX = transform.localScale.x; 
        if(Mathf.Sign(localScaleX) != _direction) //Check if the projectile is facing the right direction
            localScaleX = -localScaleX;

        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
    }

    //private void Deactivate() 
    //{
    //    gameObject.SetActive(false);
    //}
    //Use this after I add animation
}
