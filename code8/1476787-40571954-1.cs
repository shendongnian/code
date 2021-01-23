    public class RayCastRouter : MonoBehaviour, IPointerDownHandler,
           IPointerUpHandler,
           IDragHandler
    {
        public void OnDrag(PointerEventData eventData)
        {
            RaycastForwarder.Instance.notifyPointerDrag(eventData);
        }
    
        public void OnPointerDown(PointerEventData eventData)
        {
            RaycastForwarder.Instance.notifyPointerDown(eventData);
        }
    
        public void OnPointerUp(PointerEventData eventData)
        {
            RaycastForwarder.Instance.notifyPointerUp(eventData);
        }
    }
