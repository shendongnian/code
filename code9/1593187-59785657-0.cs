    [RequireComponent(typeof(RectTransform))]
    public class Draggable : MonoBehaviour, IDragHandler
    {
        private RectTransform rectTransform;
    
        private void Start()
        {
            rectTransform = GetComponent<RectTransform>();
        }
    
        public void OnDrag(PointerEventData eventData)
        {
            rectTransform.anchoredPosition += eventData.delta;
        }
    }
