    public class EventForwarder : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
    {
        WholeScreenPointer wcp = null;
        void Start()
        {
            wcp = WholeScreenPointer.Instance;
        }
    
        public void OnDrag(PointerEventData eventData)
        {
            wcp.forwardDragEvent(eventData);
        }
    
        public void OnPointerDown(PointerEventData eventData)
        {
            wcp.forwardPointerDownEvent(eventData);
        }
    
        public void OnPointerUp(PointerEventData eventData)
        {
            wcp.forwardPointerUpEvent(eventData);
        }
    }
