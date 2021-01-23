    public class FingerMove : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        public int touchCount;
        public List<int> touchID = new List<int>(6); //6 touches limit
    
        public void OnPointerDown(PointerEventData data)
        {
            Debug.Log("Pressed");
            //Check If PointerId exist, if it doesn't add to list
            if (touchID.Contains(data.pointerId))
            {
                return; //Exit if PointerId exist
            }
    
            //PointerId does not exist, add it to the list then increment touchCount
            touchID.Add(data.pointerId);
            touchCount++;
        }
    
        public void OnPointerUp(PointerEventData data)
        {
            Debug.Log("Released");
            //Check If PointerId exist, if it exist remove it from list then decrement touchCount
            if (touchID.Contains(data.pointerId))
            {
                touchID.Remove(data.pointerId);
                touchCount--;
                return;
            }
        }
    
        void Update()
        {
            Debug.Log("Touch Count: " + touchCount);
        }
    }
