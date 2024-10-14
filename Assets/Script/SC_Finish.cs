using UnityEngine;
using UnityEngine.SceneManagement;

public class SC_Finish : MonoBehaviour
{
    [SerializeField] string sceneName;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "UsedBlob")
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
