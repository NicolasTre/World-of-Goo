using UnityEngine;

public class SC_Tracing : MonoBehaviour
{
    private GameObject Target;
    [SerializeField] GameObject LINE;
    GameObject _line;

    private void Awake()
    {
        LinkView();
    }
    public void LinkView()
    {
        // chaque UsedBlob dans un radius de 2
        var overlapped = Physics2D.OverlapCircleAll(transform.position, 3f, LayerMask.GetMask("UsedBlob"));
        if (overlapped.Length >= 2)
        {
            foreach (var overlap in overlapped)
            {
                _line = Instantiate(LINE, transform.position, Quaternion.identity, transform);
                _line.gameObject.GetComponentInChildren<BoxCollider2D>().isTrigger = false;
                Target = overlap.gameObject;
                _line.GetComponent<SC_TraceUpdate>().Target = Target.transform;
            }
        }
    }
}