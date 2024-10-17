using UnityEngine;
using UnityEngine.SceneManagement;

public class SC_FinishLevel : MonoBehaviour
{

    [SerializeField] private string nameScene;

    public void OnNextLevelButton()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(nameScene);
    }

    public void OnMainMenuButton()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Main Menu");
    }
}
