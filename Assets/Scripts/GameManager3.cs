using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager3 : MonoBehaviour
{
    private bool gameHasEnded;
    public float restartDelay = 1f;
    public GameObject completeLevelUI;
    public void EndGame()
    {
        if (!gameHasEnded)
        {
            gameHasEnded = true;
            Debug.Log("game over");
            Invoke("Restart", restartDelay);
            //Restart();
        }
    }

    public void CompleteLevel()
    {
        completeLevelUI.SetActive(true);
    }
    
    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
