using UnityEngine;
using UnityEngine.SceneManagement;

public class SC_Finish : MonoBehaviour
{

    [SerializeField] private GameObject canvasFinish;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "UsedBlob")
        {
            Time.timeScale = 0f;
            canvasFinish.SetActive(true);
        }
    }
}
