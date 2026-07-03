using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D body;
    public float speed = 8f;
    public float jump_speed = 15f;
    private bool grounded;
        
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        float direction = Input.GetAxis("Horizontal");
        body.linearVelocity = new Vector2(direction * speed, body.linearVelocity.y);
        if (direction > 0.01f)
            transform.localScale = Vector2.one;
        else if (direction < -0.01f)
            transform.localScale = new Vector2 (-1, 1); //Flip sprite when moving left/right

        if (Input.GetKey(KeyCode.Space) && grounded)
            Jump();
    }
    private void Jump()
    {
        body.linearVelocity = new Vector2(body.linearVelocity.x, jump_speed);
        grounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
            grounded = true;
    }
}
