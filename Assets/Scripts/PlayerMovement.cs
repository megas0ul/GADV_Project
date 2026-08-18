using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D body;
    private BoxCollider2D boxCollider;
    [SerializeField]private LayerMask groundLayer;
    [SerializeField]private LayerMask wallLayer;
    //public LayerMask trapLayer;
    [SerializeField]private float speed = 8f;
    [SerializeField]private float jump_speed = 10f;
    [SerializeField]private float wallJumpCooldown = 0.2f;
    private Health playerHealth;
    private PlayerRespawn playerRespawn;
    private float horizontalInput;
        
    private void Awake()    
    {
        body = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        playerHealth = GetComponent<Health>();
        playerRespawn = GetComponent<PlayerRespawn>();
    }

    // Update is called once per frame
    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");//Check left (A key) or right input (D)

        if (horizontalInput > 0.01f) 
            transform.localScale = Vector3.one;
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3 (-1, 1, -1); //Flip sprite when moving left/right

        
        if (wallJumpCooldown > 0.2f)
        {
            body.linearVelocity = new Vector2(horizontalInput * speed, body.linearVelocity.y);

            if (onWall() && isGrounded())
            {
                body.gravityScale = 0;
                body.linearVelocity = Vector2.zero;
            }

            else
                body.gravityScale = 2;
            
            if (Input.GetKey(KeyCode.Space))
                Jump();
        }
        else
            wallJumpCooldown += Time.deltaTime;
    
    }
    private void Jump() //Makes the player move upwards 
    {
        if(isGrounded())
        {
            body.linearVelocity = new Vector2(body.linearVelocity.x, jump_speed);
        }
        else if (onWall() && !isGrounded()) //Wall Jump
            {
                if (horizontalInput == 0)
                {
                    body.linearVelocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 10, 0);
                    transform.localScale = new Vector3(-Mathf.Sign(transform.localScale.x), transform.localScale.y, transform.localScale.z);
                }
                else
                body.linearVelocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 4, 6); //Returns 1 when player is facing right and -1 when facing left
                wallJumpCooldown = 0;
            }
       
    }

    private void OnCollisionEnter2D(Collision2D other) //Do damage to the player when colliding with traps
    {
        if (other.gameObject.CompareTag("Trap"))
        {
            playerHealth.TakeDamage(1);         
        }
    }

    private bool isGrounded()//Check if player is on the ground
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }
    private bool onWall()//Check if player is on the wall
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, new Vector2(transform.localScale.x, 0), 0.1f, wallLayer);
        return raycastHit.collider != null;
    }

    public bool canAttack() //Check if player is not moving and is grounded before letting them attack.
    {
        return isGrounded();
    }
}
