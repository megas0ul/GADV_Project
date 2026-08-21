using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    private Transform currentCheckpoint; //To store last checkpoint
    private Health playerHealth;
    private UIManager uiManager;
    private void Awake()
    {
        playerHealth = GetComponent<Health>();
        uiManager = FindAnyObjectByType<UIManager>();
    }
    public void CheckRespawn() //For checkpoints 
    {
        if (currentCheckpoint == null)
        {
            //Show Game Over
            uiManager.GameOver();
            return; //Don't execute the rest of this function
        }
        transform.position = currentCheckpoint.position; //Move player to the checkpoint position
        //Restore player health
        playerHealth.Respawn();
        //Move camera to checkpoint room (Needs to be placed as a child of the room object)
        Camera.main.GetComponent<CameraController>().MoveToNewRoom(currentCheckpoint.parent);
    }

    //Activate Checkpoints
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Checkpoint")
        {
            currentCheckpoint = collision.transform; //Store the checkpoint that we activated as a new one
            collision.GetComponent<Collider2D>().enabled = false; //Deactivate checkpoint collider
        }
    }
}
