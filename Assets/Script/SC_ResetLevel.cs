using UnityEngine;
using UnityEngine.SceneManagement;

public class SC_ResetLevel : MonoBehaviour
{
    [SerializeField] private string nameScene;


    public void OnResetButton()
    {
        SceneManager.LoadScene(nameScene);
    }
}
