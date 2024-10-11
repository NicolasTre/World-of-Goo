using UnityEngine;

public class SC_TraceUpdate : MonoBehaviour
{
    float dist;
    public Transform Target;
    public SC_DragAndDropGoo moveBlob;

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(Target.position, transform.position) > 3f)
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
