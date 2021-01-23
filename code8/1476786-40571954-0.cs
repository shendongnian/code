    public class RaycastForwarder : MonoBehaviour
    {
        List<PhysicsRaycaster> rayCast3D = new List<PhysicsRaycaster>();
        List<RaycastResult> rayCast3DResult = new List<RaycastResult>();
    
        private static RaycastForwarder localInstance;
        public static RaycastForwarder Instance { get { return localInstance; } }
    
    
        private void Awake()
        {
            if (localInstance != null && localInstance != this)
            {
                Destroy(this.gameObject);
            }
            else
            {
                localInstance = this;
            }
        }
    
        public void notifyPointerDown(PointerEventData eventData)
        {
            findColliders(eventData, PointerEventType.Down);
        }
    
        public void notifyPointerUp(PointerEventData eventData)
        {
            findColliders(eventData, PointerEventType.Up);
        }
    
        public void notifyPointerDrag(PointerEventData eventData)
        {
            findColliders(eventData, PointerEventType.Drag);
        }
    
        private void findColliders(PointerEventData eventData, PointerEventType evType)
        {
            UpdateRaycaster();
    
            //Loop Through All Normal Collider(3D/Mesh Renderer) and throw Raycast to each one
            for (int i = 0; i < rayCast3D.Count; i++)
            {
                //Send Raycast to all GameObject with 3D Collider
                rayCast3D[i].Raycast(eventData, rayCast3DResult);
                sendRayCast(eventData, evType);
            }
            //Reset Result
            rayCast3DResult.Clear();
        }
    
        private void sendRayCast(PointerEventData eventData, PointerEventType evType)
        {
            //Loop over the RaycastResult and simulate the pointer event
            for (int i = 0; i < rayCast3DResult.Count; i++)
            {
                GameObject target = rayCast3DResult[i].gameObject;
                PointerEventData evData = createEventData(rayCast3DResult[i]);
    
                if (evType == PointerEventType.Drag)
                {
                    ExecuteEvents.Execute<IDragHandler>(target,
                                            evData,
                                            ExecuteEvents.dragHandler);
                }
    
                if (evType == PointerEventType.Down)
                {
                    ExecuteEvents.Execute<IPointerDownHandler>(target,
                                   evData,
                                   ExecuteEvents.pointerDownHandler);
                }
    
                if (evType == PointerEventType.Up)
                {
                    ExecuteEvents.Execute<IPointerUpHandler>(target,
                        evData,
                        ExecuteEvents.pointerUpHandler);
                }
            }
        }
    
        private PointerEventData createEventData(RaycastResult rayResult)
        {
            PointerEventData evData = new PointerEventData(EventSystem.current);
            evData.pointerCurrentRaycast = rayResult;
            return evData;
        }
    
        //Get all PhysicsRaycaster in the scene
        private void UpdateRaycaster()
        {
            convertToList(FindObjectsOfType<PhysicsRaycaster>(), rayCast3D);
        }
    
        private void convertToList(PhysicsRaycaster[] fromComponent, List<PhysicsRaycaster> toComponent)
        {
            //Clear and copy new Data
            toComponent.Clear();
            for (int i = 0; i < fromComponent.Length; i++)
            {
                toComponent.Add(fromComponent[i]);
            }
        }
    
        public enum PointerEventType
        {
            Drag, Down, Up
        }
    }
