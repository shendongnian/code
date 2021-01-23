    using UnityEngine;
    using UnityEngine.EventSystems;
    
    public class DragInput : MonoBehaviour, IPointerDownHandler, IDragHandler, IEndDragHandler
    {
        Camera mainCamera;
        float zAxis = 0;
        Vector3 clickOffset = Vector3.zero;
    
        // Use this for initialization
        void Start()
        {
            mainCamera = Camera.main;
            zAxis = transform.position.z;
        }
    
        public void OnPointerDown(PointerEventData eventData)
        {
            clickOffset = transform.position - mainCamera.ScreenPointToWoldOnPlane(eventData.position, zAxis);
        }
    
        public void OnDrag(PointerEventData eventData)
        {
            transform.position = mainCamera.ScreenPointToWoldOnPlane(eventData.position, zAxis) + clickOffset;
        }
    
        public void OnEndDrag(PointerEventData eventData)
        {
    
        }
    }
    
    public static class extensionMethod
    {
        public static Vector3 ScreenPointToWoldOnPlane(this Camera cam, Vector3 screenPosition, float zPos)
        {
            float enterDist;
            Plane plane = new Plane(Vector3.forward, new Vector3(0, 0, zPos));
            Ray rayCast = cam.ScreenPointToRay(screenPosition);
            plane.Raycast(rayCast, out enterDist);
            return rayCast.GetPoint(enterDist);
        }
    }
