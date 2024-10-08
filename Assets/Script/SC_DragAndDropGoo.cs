using UnityEngine;


public class SC_DragAndDropGoo : MonoBehaviour
{
    Vector3 offset;


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
}
