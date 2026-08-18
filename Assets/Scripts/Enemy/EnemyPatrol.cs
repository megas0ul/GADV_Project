using Unity.VisualScripting;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [Header ("Patrol Points")]
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;

    [Header ("Enemy")]
    [SerializeField] private Transform enemy;

    [Header ("Movement Parameters")]
    [SerializeField] private float speed;
    private Vector3 initScale; //Initial scale
    private bool movingLeft;

    [Header ("Idle Behavior")] //For future Idle animations of enemy
    [SerializeField] private float idleDuration;
    private float idleTimer;
    
    private void Awake()
    {
        initScale = enemy.localScale;
    }

    void Update()
    {
        if(movingLeft)
        {
            if(enemy.position.x >= leftEdge.position.x)//If enemy reaces the left edge, it changes direction to the right
                MoveInDirection(-1);
            else
            {
                DirectionChange();
            }
        }
        else 
        {
            if (enemy.position.x <= rightEdge.position.x) //Switches to the left edge after reaching the right
                MoveInDirection(1);
            else
            {
                DirectionChange();
            }
        }
    }

    private void DirectionChange() //Changes direction of object
    {
        idleTimer += Time.deltaTime;
        
        if (idleTimer > idleDuration)
        movingLeft = !movingLeft;
    }
    private void MoveInDirection(int _direction) //Move left or right
    {
        idleTimer = 0;
        //Make enemy face the right direction
        enemy.localScale = new Vector3(Mathf.Abs(initScale.x) * _direction, initScale.y, initScale.z);

        //Move in that direction
        enemy.position = new Vector3(enemy.position.x + Time.deltaTime * _direction * speed,
            enemy.position.y, enemy.position.z);
    }
}
