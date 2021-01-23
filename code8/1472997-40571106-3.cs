    public class Test : MonoBehaviour, IPointerCounterHandler, IPointerDownHandler, IPointerUpHandler
    {
        public void OnPointerCounterChanged(int touchCount)
        {
            Debug.Log("Simple Finger Counter: " + touchCount);
        }
    
        public void OnPointerCounterChanged(PointerCounterEventData touchCountData)
        {
            PointerCounterInfo moreEventData = touchCountData.touchCountData;
    
            Debug.Log("Finger TouchCount: " + moreEventData.touchCount);
            Debug.Log("Finger PointerId: " + moreEventData.pointerId);
            Debug.Log("Finger Pointer State: " + moreEventData.pointerState);
            Debug.Log("Finger Target: " + moreEventData.target.name);
    
            //Can also access PointerEventData
            PointerEventData eventData = touchCountData.touchCountData.eventData;
            Debug.Log("Click Time!: " + eventData.clickTime);
        }
    
        public void OnPointerDown(PointerEventData eventData)
        {
            PointerCounterEventData.notifyPointerDown(EventSystem.current, eventData, this.gameObject);
        }
    
        public void OnPointerUp(PointerEventData eventData)
        {
            PointerCounterEventData.notifyPointerUp(EventSystem.current, eventData, this.gameObject);
        }
    }
