    public class ThroughEventScript : MonoBehaviour, IPointerDownHandler
    {
    
        public void OnPointerDown(PointerEventData eventData)
        {
            rethrowRaycast(eventData, eventData.pointerCurrentRaycast.gameObject);
    
            //DO STUFF WITH THE OBJECT HIT BELOW
            Debug.Log("Hit: " + eventData.pointerCurrentRaycast.gameObject.name);
        }
    
        void rethrowRaycast(PointerEventData eventData, GameObject excludeGameObject)
        {
            PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
    
            pointerEventData.position = eventData.pressPosition;
            //pointerEventData.position = eventData.position;}
    
            //Where to store Raycast Result
            List<RaycastResult> raycastResult = new List<RaycastResult>();
    
            //Rethrow the raycast to include everything regardless of their Z position
            EventSystem.current.RaycastAll(pointerEventData, raycastResult);
    
            //Debug.Log("Other GameObject hit");
            for (int i = 0; i < raycastResult.Count; i++)
            {
                //Debug.Log(raycastResult[i].gameObject.name);
    
                //Don't Rethrow Raycayst for the first GameObject that is hit
                if (excludeGameObject != null && raycastResult[i].gameObject != excludeGameObject)
                {
                    //Re-simulate OnPointerDown on every Object hit
                    simulateCallbackFunction(raycastResult[i].gameObject);
                }
            }
        }
    
        //This causes functions such as OnPointerDown to be called again
        void simulateCallbackFunction(GameObject target)
        {
            PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
            //pointerEventData.ra
            RaycastResult res = new RaycastResult();
            res.gameObject = target;
            pointerEventData.pointerCurrentRaycast = res;
            ExecuteEvents.Execute(target, pointerEventData, ExecuteEvents.pointerDownHandler);
        }
    }
