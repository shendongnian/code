    using UnityEngine;
    using UnityEngine.EventSystems;
    
    public class MapClickDetector : MonoBehaviour, IPointerClickHandler, IPointerDownHandler,
        IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
    {
        MapManager mapManager;
    
        void Start()
        {
            addPhysicsRaycaster();
    
            mapManager = GameObject.Find("MapManager").GetComponent<MapManager>();
        }
    
        void addPhysicsRaycaster()
        {
            PhysicsRaycaster physicsRaycaster = GameObject.FindObjectOfType<PhysicsRaycaster>();
            if (physicsRaycaster == null)
            {
                Camera.main.gameObject.AddComponent<PhysicsRaycaster>();
            }
        }
    
        public void OnPointerClick(PointerEventData eventData)
        {
            mapManager.mapclick(gameObject);
        }
    
        public void OnPointerDown(PointerEventData eventData)
        {
            mapManager.mapMouseDown(gameObject);
        }
    
        public void OnPointerUp(PointerEventData eventData)
        {
            mapManager.mapMouseUp(gameObject);
        }
    
        public void OnPointerEnter(PointerEventData eventData)
        {
            mapManager.mapMouseEnter(gameObject);
        }
    
        public void OnPointerExit(PointerEventData eventData)
        {
            mapManager.mapMouseExit(gameObject);
        }
    }
