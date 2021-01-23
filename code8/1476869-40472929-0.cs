    public class Pressed : MonoBehaviour, IPointerDownHandler,IPointerUpHandler
    {
        bool pressed = false;
    
        public void OnPointerDown(PointerEventData eventData)
        {
            pressed = true;
        }
    
        public void OnPointerUp(PointerEventData eventData)
        {
            pressed = false;
        }
    
        void Update()
        {
            if (pressed)
            {
                Debug.Log("Pressed Down!");
                //Put Code to repeat here
            }
        }
    }
