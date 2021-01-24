    using UnityEngine.EventSystems;
    
    public class CubeDrag : MonoBehaviour, IPointerDownHandler, IDragHandler, IEndDragHandler
    {
        Camera mainCamera;
        float zAxis = 0;
        Vector3 clickOffset = Vector3.zero;
    
        // Use this for initialization
        void Start()
        {
            addEventSystem();
            zAxis = transform.position.z;
        }
    
        public void OnPointerDown(PointerEventData eventData)
        {
            Vector3 tempPos = eventData.position;
            tempPos.z = Vector3.Distance(transform.position, Camera.main.transform.position);
            clickOffset = transform.position - mainCamera.ScreenToWorldPoint(tempPos);
            Debug.Log("Mouse Down");
        }
    
        public void OnDrag(PointerEventData eventData)
        {
            Vector3 tempPos = eventData.position;
            tempPos.z = Vector3.Distance(transform.position, Camera.main.transform.position);
            Vector3 tempVec = mainCamera.ScreenToWorldPoint(tempPos);
            tempVec.z = zAxis;
    
            transform.position = tempVec;
            Debug.Log("Dragging Cube");
        }
    
        public void OnEndDrag(PointerEventData eventData)
        {
    
        }
    
        void addEventSystem()
        {
            mainCamera = Camera.main;
            if (mainCamera.GetComponent<PhysicsRaycaster>() == null)
                mainCamera.gameObject.AddComponent<PhysicsRaycaster>();
    
            EventSystem eveSys = GameObject.FindObjectOfType(typeof(EventSystem)) as EventSystem;
            if (eveSys == null)
            {
                GameObject tempObj = new GameObject("EventSystem");
                eveSys = tempObj.AddComponent<EventSystem>();
            }
    
            StandaloneInputModule stdIM = GameObject.FindObjectOfType(typeof(StandaloneInputModule)) as StandaloneInputModule;
            if (stdIM == null)
                stdIM = eveSys.gameObject.AddComponent<StandaloneInputModule>();
        }
    }
