    using UnityEngine.EventSystems;
    
    public class Dragger: MonoBehaviour,
        IBeginDragHandler, IEndDragHandler
    {
        public void OnBeginDrag(PointerEventData eventData)
        {
            Debug.Log("Drag Begin");
        }
    
        public void OnDrag(PointerEventData eventData)
        {
            Debug.Log("Dragging");
        }
    
        public void OnEndDrag(PointerEventData eventData)
        {
            Debug.Log("Drag Ended");
        }
    }
