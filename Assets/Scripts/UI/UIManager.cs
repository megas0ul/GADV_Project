using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField]private GameObject gameOverScreen;
    [SerializeField]private GameObject gameWinScreen;
    [SerializeField]private GameObject MainScreen;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Awake()
    {
        gameOverScreen.SetActive(false); //Disable Game Over screen just in case I forget
        gameWinScreen.SetActive(false); //Same for Victory screen
    }
    public void GameOver()
    {
        gameOverScreen.SetActive(true);
    }

    public void GameVictory()
    {
        gameWinScreen.SetActive(true);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //Reloads the current scene located in build profile
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0); //Goes back to main Menu
    }

    public void FirstLevel()
    {
        SceneManager.LoadScene(1); //Load Level 1
    }
    public void SecLevel()
    {
        SceneManager.LoadScene(2); //Loads level 2
    }
    public void Quit()
    {
        Application.Quit(); //Closes the app
    }
}
