using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;


public class SC_DragAndDropGoo : MonoBehaviour
{
    Vector3 offset;

    private GameObject Target; // goo qui sont maintenue par des liaison
    GameObject _line;
    Collider2D[] overlappedP;
    bool IsGrabed = false;
    static bool AlreadyOneGrabed = false;

    [SerializeField] GameObject LINE; // prefab pour la prévisualisation de la distance de liaison entre 2 goo
    [SerializeField] GameObject UsedBlob;
    
    public List<GameObject> Connect = new List<GameObject>();

    private void Update()
    {
        overlappedP = Physics2D.OverlapCircleAll(transform.position, 5, LayerMask.GetMask("UsedBlob"));
        if (IsGrabed)
        {
            // chaque UsedBlob dans un radius de 5
            overlappedP = Physics2D.OverlapCircleAll(transform.position, 5, LayerMask.GetMask("UsedBlob"));
            if (overlappedP.Length > 1)
            {
                foreach (var overlap in overlappedP)
                {
                    if (!Connect.Contains(overlap.gameObject))
                    {
                        Connect.Add(overlap.gameObject);
                        if (transform.childCount < overlappedP.Length)
                        {
                            _line = Instantiate(LINE, transform.position, Quaternion.identity, transform);
                            Target = overlap.gameObject;
                            _line.GetComponent<SC_TraceUpdate>().Target = Target.transform;
                        }
                    }
                }
            }

            if (Connect != null)
            {
                Connect.RemoveAll(x => Vector2.Distance(transform.position, x.transform.position) > 5);
            }
        }
    }

    private void OnMouseDown()
    {
        offset = transform.position - MouseWorldPosition();
    }
    private void OnMouseDrag()
    {
        transform.position = MouseWorldPosition() + offset;
    }

    Vector3 MouseWorldPosition()
    {
        var mouseScreenPos = Input.mousePosition;
        mouseScreenPos.z = Camera.main.WorldToScreenPoint(transform.position).z;
        return Camera.main.ScreenToWorldPoint(mouseScreenPos);
    }

    public void Interact()
    {
        if (!AlreadyOneGrabed)
        {
            IsGrabed = !IsGrabed;
            transform.GetComponent<Rigidbody2D>().gravityScale = 0;

            if (!IsGrabed)
            {
                Link();
                transform.GetComponent<Rigidbody2D>().gravityScale = 1;
            }
        }
    }

    private void Link()
    {
        // chaque UsedBlob dans un radius de 5
        var overlapped = Physics2D.OverlapCircleAll(transform.position, 5, LayerMask.GetMask("UsedBlob"));
        if (overlapped.Length > 1)
        {
            GameObject UBlob = Instantiate(UsedBlob, transform.position, Quaternion.identity);

            foreach (var overlap in overlapped)
            {
                // Ajout du spring joint pour chaque cible
                var spring = UBlob.transform.gameObject.AddComponent<SpringJoint2D>();
                spring.frequency = 9;
                spring.connectedBody = overlap.GetComponent<Rigidbody2D>();
                spring.autoConfigureDistance = true;
                //Tracing _Target = overlap.transform;
            }

            Destroy(gameObject);
        }

    }
}
