using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class SelectionArrow : MonoBehaviour
{
    [SerializeField]private RectTransform[] options;
    private RectTransform rect;
    private int currentPosition;

    private void Awake()
    {
        rect = GetComponent<RectTransform>();
    }

    private void Update() //Moves arrow up or down when W/up arrow key or S and down arrow key is pressed
    {
        if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            ChangePosition(-1);
        if(Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            ChangePosition(-1);

        if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.E))
            Interact();
    }
    
    private void ChangePosition(int _change) //Moving the arrow
    {
        currentPosition += _change;

        if(currentPosition < 0)
            currentPosition = options.Length - 1;
        else if (currentPosition > options.Length -1)
            currentPosition = 0;

        //Assign the Y position of the current option to the arrow which moves it up or down
        rect.position = new Vector3(rect.position.x, options[currentPosition]. position.y, 0);
    }

    private void Interact()
    {
        //Access the button component and call its function
        options[currentPosition].GetComponent<Button>().onClick.Invoke();
    }

}
