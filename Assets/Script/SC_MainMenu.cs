using UnityEngine;
using UnityEngine.SceneManagement;

public class SC_MainMenu : MonoBehaviour
{

    public void OnLvl1Button()
    {
        SceneManager.LoadScene("Niveau 1");
    }

    public void OnLvl2Button()
    {
        SceneManager.LoadScene("Niveau 2");
    }

    public void OnLvl3Button()
    {
        SceneManager.LoadScene("Niveau 3");
    }

    public void OnLvl4Button()
    {
        SceneManager.LoadScene("Niveau 4");
    }

    public void OnYesButton()
    {
        Application.Quit();
    }
}
