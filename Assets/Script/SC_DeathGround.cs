using UnityEngine;
using UnityEngine.SceneManagement;

public class SC_DeathGround : MonoBehaviour
{
    [SerializeField] private string sceneName;
    [SerializeField] private GameObject blobSpawnPoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "UsedBlob")
        {
            SceneManager.LoadScene(sceneName);
        }
        else if (collision.gameObject.tag == "BlobToUse")
        {
            collision.gameObject.transform.position = blobSpawnPoint.transform.position;
        }

    }
}
