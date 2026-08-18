using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField]private GameObject gameOverScreen;
    [SerializeField]private GameObject victoryScreen;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Awake()
    {
        gameOverScreen.SetActive(false); //Disable Game Over screen just in case
    }
    public void GameOver()
    {
        gameOverScreen.SetActive(true);
    }

    // Update is called once per frame
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void Quit()
    {
        Application.Quit(); //Closes the app
    }
}
