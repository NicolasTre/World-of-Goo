using UnityEngine;
using UnityEngine.SceneManagement;

public class SC_DeathGround : MonoBehaviour
{
    [SerializeField] private string sceneName;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "UsedBlob")
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
