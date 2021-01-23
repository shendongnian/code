    public class SpriteDetector : MonoBehaviour, IPointerDownHandler
    {
        void Start()
        {
            addPhysics2DRaycaster();
        }
    
        void addPhysics2DRaycaster()
        {
            Physics2DRaycaster physicsRaycaster = GameObject.FindObjectOfType<Physics2DRaycaster>();
            if (physicsRaycaster == null)
            {
                Camera.main.gameObject.AddComponent<Physics2DRaycaster>();
            }
        }
    
        public void OnPointerDown(PointerEventData eventData)
        {
            Debug.Log("Clicked: " + eventData.pointerCurrentRaycast.gameObject.name);
        }
    
        //Implement Other Events from Method 1
    }
