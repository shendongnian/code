    public class ButtonDetector : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        public bool clicked = false;
    
        public void OnPointerDown(PointerEventData eventData)
        {
            clicked = true;
            //Debug.Log("Pointer Down!");
        }
    
        public void OnPointerUp(PointerEventData eventData)
        {
            //Reset
            clicked = false;
            // Debug.Log("Pointer Up!");
        }
    
        // Use this for initialization
        void Start()
        {
    
        }
    }
