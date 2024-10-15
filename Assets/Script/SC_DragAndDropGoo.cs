using System.Collections.Generic;
using UnityEngine;


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
        if (IsGrabed) // creation of preline if a blob is grab and if you have a other usedblob a proxity
        {
            
            overlappedP = Physics2D.OverlapCircleAll(transform.position, 3f, LayerMask.GetMask("UsedBlob")); // check chaque UsedBlob dans un radius de 3
            if (overlappedP.Length >= 2)
            {
                foreach (var overlap in overlappedP)
                {
                    if (!Connect.Contains(overlap.gameObject)) // check if u don't have already usedblob in the circle overlapped in the list   
                    {
                        Connect.Add(overlap.gameObject);
                        if (transform.childCount < overlappedP.Length && overlappedP.Length > 1)
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
                Connect.RemoveAll(x => Vector2.Distance(transform.position, x.transform.position) > 3f);
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
        transform.GetComponent<CircleCollider2D>().isTrigger = true;
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
                transform.GetComponent<CircleCollider2D>().isTrigger = false;
            }
        }
    }

    private void Link() // creation of sping join
    {
        // chaque UsedBlob dans un radius de 3
        var overlapped = Physics2D.OverlapCircleAll(transform.position, 3f, LayerMask.GetMask("UsedBlob"));
        if (overlapped.Length >= 2)
        {
            GameObject UBlob = Instantiate(UsedBlob, transform.position, Quaternion.identity);

            foreach (var overlap in overlapped)
            {
                // Ajout du spring joint pour chaque cible
                var spring = UBlob.transform.gameObject.AddComponent<SpringJoint2D>();
                spring.frequency = 7;
                spring.connectedBody = overlap.GetComponent<Rigidbody2D>();
                spring.autoConfigureDistance = true;
                //Tracing _Target = overlap.transform;
            }

            Destroy(gameObject); // destroy the last prefab of blob and preline
        }

    }
}
