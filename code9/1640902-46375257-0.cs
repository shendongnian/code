    public class UIPresser : MonoBehaviour, IPointerDownHandler,
        IPointerUpHandler
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
                MoveLeft();
        }
    
        public void MoveLeft()
        {
            transform.RotateAround(Camera.main.transform.position, Vector3.up, -rotation / 4 * Time.deltaTime);
            infopanel.RotateAround(Camera.main.transform.position, Vector3.up, -rotation / 4 * Time.deltaTime);
        }
    }
