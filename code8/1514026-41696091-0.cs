    public class YourCode : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        bool pointerDown = false;
    
        public void OnPointerDown(PointerEventData eventData)
        {
            pointerDown = true;
        }
    
        public void OnPointerUp(PointerEventData eventData)
        {
            pointerDown = false;
        }
    
        void Update()
        {
            if (pointerDown)
            {
                //Your Code
            }
        }
    }
