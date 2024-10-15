using System.Collections;
using System.Collections.Generic;
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

    public void OnYesButton()
    {
        Application.Quit();
    }
}
