    public class Test : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
    {
        void Start()
        {
            //Register this GameObject so that it will receive events from WholeScreenPointer script
            WholeScreenPointer.Instance.registerGameObject(this.gameObject);
        }
    
        public void OnDrag(PointerEventData eventData)
        {
            Debug.Log("Dragging: ");
        }
    
        public void OnPointerDown(PointerEventData eventData)
        {
            Debug.Log("Pointer Down: ");
        }
    
        public void OnPointerUp(PointerEventData eventData)
        {
            Debug.Log("Pointer Up: ");
        }
    
        void OnDisable()
        {
            WholeScreenPointer.Instance.unRegisterGameObject(this.gameObject);
        }
    }
