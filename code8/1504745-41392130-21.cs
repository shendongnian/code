    public class MeshDetector : MonoBehaviour, IPointerDownHandler
    {
        void Start()
        {
            addPhysicsRaycaster();
        }
    
        void addPhysicsRaycaster()
        {
            PhysicsRaycaster physicsRaycaster = GameObject.FindObjectOfType<PhysicsRaycaster>();
            if (physicsRaycaster == null)
            {
                Camera.main.gameObject.AddComponent<PhysicsRaycaster>();
            }
        }
    
        public void OnPointerDown(PointerEventData eventData)
        {
            Debug.Log("Clicked: " + eventData.pointerCurrentRaycast.gameObject.name);
        }
    
        //Implement Other Events from Method 1
    }
