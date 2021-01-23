    public class DragControl : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        private bool m_Used;
        private Vector3 m_MouseStartPosition;
        private Vector3 m_ItemStartPosition;
        public void Start()
        {
            m_Used = false;
        }
        public void Update()
        {
            if(m_Used)
            {
                GetComponent<RectTransform>().anchoredPosition = new Vector2(m_ItemStartPosition.x + (Input.mousePosition.x - m_MouseStartPosition.x), m_ItemStartPosition.y + (Input.mousePosition.y - m_MouseStartPosition.y));
                // or you can set the y value to m_ItemStartPosition.y only if you don't want the paddle to move on Y axis
            }
        }
        public void OnPointerDown(PointerEventData eventData)
        {
            m_Used = true;
            m_MouseStartPosition = Input.mousePosition;
            m_ItemStartPosition = GetComponent<RectTransform>().anchoredPosition;
        }
        public void OnPointerUp(PointerEventData eventData)
        {
            m_Used = false;
        }
    }
