using UnityEngine;

public class Slime_Player : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
                _direction = Vector2.left;
            } else if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
                _direction = Vector2.right;
            } else {
                _direction = Vector2.zero;
            }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
