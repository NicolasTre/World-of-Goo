using UnityEngine;

public class SC_GroundCheck : MonoBehaviour
{

    private Rigidbody2D rbUsedBlob;

    private void Start()
    {
        rbUsedBlob = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            rbUsedBlob.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }
}
