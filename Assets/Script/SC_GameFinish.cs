using UnityEngine;
using UnityEngine.SceneManagement;

public class SC_GameFinish : MonoBehaviour
{
    public void OnMainMenuButton()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void OnRestartButton()
    {
        SceneManager.LoadScene("Niveau 1");
    }
}
