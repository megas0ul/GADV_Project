using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D body;
    private BoxCollider2D boxCollider;
    //public LayerMask groundLayer; Test usings layers vs tags / Might use raycasting
    //public LayerMask wallLayer;
    //public LayerMask trapLayer;
    public float speed = 8f;
    public float jump_speed = 15f;
    private bool grounded;
    private float horizontalInput;
        
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");//Check left (A key) or right input (D)
        //Calculate speed moving left or right
        body.linearVelocity = new Vector2(horizontalInput * speed, body.linearVelocity.y);
        if (horizontalInput > 0.01f) 
            transform.localScale = Vector2.one;
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector2 (-1, 1); //Flip sprite when moving left/right

        if (Input.GetKey(KeyCode.Space) && grounded == true)
            Jump();
    }
    private void Jump()
    {
        body.linearVelocity = new Vector2(body.linearVelocity.x, jump_speed);
    }

    private void OnCollisionEnter2D(Collision2D other) //Check if player is on the ground
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            Vector3 normal = other.GetContact(0).normal;
            if(normal == Vector3.up)
            {
            grounded = true;
            }
        }
        else if (other.gameObject.CompareTag("Trap"))
        {
            transform.position = new Vector2(-7f, -3.55f);
        }
    }

    private void OnCollisionExit2D(Collision2D other) //Check if player is on the ground
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            grounded = false; 
        }
    }

    private void takeDamage()
    {

    }

    public bool canAttack()
    {
        return horizontalInput == 0 && grounded;
    }
}
