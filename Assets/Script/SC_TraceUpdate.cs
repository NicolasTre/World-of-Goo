using UnityEngine;

public class SC_TraceUpdate : MonoBehaviour
{
    float dist;
    public Transform Target;

    // Update is called once per frame
    void Update()
    {
        var overlapped = Physics2D.OverlapCircleAll(transform.position, 3f, LayerMask.GetMask("UsedBlob"));

        if (Vector2.Distance(Target.position, transform.position) > 3f && overlapped.Length <=1)
        {
            Destroy(gameObject);
        }

        dist = Vector3.Distance(transform.position, Target.transform.position);

        // Rotate
        float angle = Mathf.Atan2(Target.position.y - transform.position.y, Target.position.x - transform.position.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);

        // Distance
        transform.localScale = new(dist / transform.parent.localScale.x, 0.3f, 1f);
    }
}
