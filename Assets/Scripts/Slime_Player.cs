using UnityEngine;

public class Slime_Player : MonoBehaviour
{
    private Rigidbody2D _myRb;
    private Vector2 _direction;
    public float speed = 8f;
    public float jump_speed = 3f;
        
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _myRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A)) {
            _direction = Vector2.left;
        } else if(Input.GetKey(KeyCode.D)) {
            _direction = Vector2.right;
        } else if(Input.GetKey(KeyCode.Space)) {  
            _myRb.AddForce(transform.up * jump_speed);
        } else {
            _direction = Vector2.zero;
        }
    }
    void FixedUpdate()
    {
        if(_direction == Vector2.zero) {
            return;
        }
        _myRb.linearVelocity = new Vector2(_direction.x * speed, _myRb.linearVelocity.y);
    }
}
