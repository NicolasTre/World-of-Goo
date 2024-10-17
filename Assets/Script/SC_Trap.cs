using UnityEngine;

public class SC_Trap : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "UsedBlob" )
        {
            Destroy(collision.gameObject);
        }
    }
}
