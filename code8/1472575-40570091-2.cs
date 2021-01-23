    public class EventUnBlocker : MonoBehaviour
    {
        List<GraphicRaycaster> grRayCast = new List<GraphicRaycaster>(); //UI
        List<Physics2DRaycaster> phy2dRayCast = new List<Physics2DRaycaster>(); //Collider 2D (Sprite Renderer)
        List<PhysicsRaycaster> phyRayCast = new List<PhysicsRaycaster>(); //Normal Collider(3D/Mesh Renderer)
    
        List<RaycastResult> resultList = new List<RaycastResult>();
    
        //For Detecting button click and sending fake Button Click to UI Buttons
        Dictionary<int, GameObject> pointerIdToGameObject = new Dictionary<int, GameObject>();
    
        // Use this for initialization
        void Start()
        {
    
        }
    
        public void sendArtificialUIEvent(Component grRayCast, PointerEventData eventData, PointerEventType evType)
        {
            //Route to all Object in the RaycastResult
            for (int i = 0; i < resultList.Count; i++)
            {
                /*Do something if it is NOT this GameObject. 
                 We don't want any other detection on this GameObject
                 */
    
                if (resultList[i].gameObject != this.gameObject)
                {
                    //Check if this is UI
                    if (grRayCast is GraphicRaycaster)
                    {
                        //Debug.Log("UI");
                        routeEvent(resultList[i], eventData, evType, true);
                    }
    
                    //Check if this is Collider 2D/SpriteRenderer
                    if (grRayCast is Physics2DRaycaster)
                    {
                        //Debug.Log("Collider 2D/SpriteRenderer");
                        routeEvent(resultList[i], eventData, evType, false);
                    }
    
                    //Check if this is Collider/MeshRender
                    if (grRayCast is PhysicsRaycaster)
                    {
                        //Debug.Log("Collider 3D/Mesh");
                        routeEvent(resultList[i], eventData, evType, false);
                    }
                }
            }
        }
    
        //Creates fake PointerEventData that will be used to make PointerEventData for the callback functions
        PointerEventData createEventData(RaycastResult rayResult)
        {
            PointerEventData fakeEventData = new PointerEventData(EventSystem.current);
            fakeEventData.pointerCurrentRaycast = rayResult;
            return fakeEventData;
        }
    
        private void routeEvent(RaycastResult rayResult, PointerEventData eventData, PointerEventType evType, bool isUI = false)
        {
            bool foundKeyAndValue = false;
    
            GameObject target = rayResult.gameObject;
    
            //Make fake GameObject target
            PointerEventData fakeEventData = createEventData(rayResult);
    
    
            switch (evType)
            {
                case PointerEventType.Drag:
    
                    //Send/Simulate Fake OnDrag event
                    ExecuteEvents.Execute<IDragHandler>(target, fakeEventData,
                              ExecuteEvents.dragHandler);
                    break;
    
                case PointerEventType.Down:
    
                    //Send/Simulate Fake OnPointerDown event
                    ExecuteEvents.Execute<IPointerDownHandler>(target,
                             fakeEventData,
                              ExecuteEvents.pointerDownHandler);
    
                    //Code Below is for UI. break out of case if this is not UI
                    if (!isUI)
                    {
                        break;
                    }
                    //Prepare Button Click. Should be sent in the if PointerEventType.Up statement
                    Button buttonFound = target.GetComponent<Button>();
    
                    //If pointerId is not in the dictionary add it
                    if (buttonFound != null)
                    {
                        if (!dictContains(eventData.pointerId))
                        {
                            dictAdd(eventData.pointerId, target);
                        }
                    }
    
                    //Bug in Unity with GraphicRaycaster  and Toggle. Have to use a hack below
                    //Toggle Toggle component
                    Toggle toggle = null;
                    if ((target.name == "Checkmark" || target.name == "Label") && toggle == null)
                    {
                        toggle = target.GetComponentInParent<Toggle>();
                    }
    
                    if (toggle != null)
                    {
                        //Debug.LogWarning("Toggled!: " + target.name);
                        toggle.isOn = !toggle.isOn;
                        //Destroy(toggle.gameObject);
                    }
                    break;
    
                case PointerEventType.Up:
    
                    //Send/Simulate Fake OnPointerUp event
                    ExecuteEvents.Execute<IPointerUpHandler>(target,
                            fakeEventData,
                            ExecuteEvents.pointerUpHandler);
    
                    //Code Below is for UI. break out of case if this is not UI
                    if (!isUI)
                    {
                        break;
                    }
    
                    //Send Fake Button Click if requirement is met
                    Button buttonPress = target.GetComponent<Button>();
    
                    /*If pointerId is in the dictionary, check 
                     
                     */
                    if (buttonPress != null)
                    {
                        if (dictContains(eventData.pointerId))
                        {
                            //Check if GameObject matches too. If so then this is a valid Click
                            for (int i = 0; i < resultList.Count; i++)
                            {
                                GameObject tempButton = resultList[i].gameObject;
                                if (tempButton != this.gameObject && dictContains(eventData.pointerId, tempButton))
                                {
                                    foundKeyAndValue = true;
                                    //Debug.Log("Button ID and GameObject Match! Sending Click Event");
    
                                    //Send/Simulate Fake Click event to the Button
                                    ExecuteEvents.Execute<IPointerClickHandler>(tempButton,
                                          new PointerEventData(EventSystem.current),
                                          ExecuteEvents.pointerClickHandler);
                                }
                            }
                        }
                    }
                    break;
            }
    
            //Remove pointerId since it exist 
            if (foundKeyAndValue)
            {
                dictRemove(eventData.pointerId);
            }
        }
    
        void routeOption(PointerEventData eventData, PointerEventType evType)
        {
            UpdateRaycaster();
            if (WholeScreenPointer.Instance.simulateUIEvent)
            {
                //Loop Through All GraphicRaycaster(UI) and throw Raycast to each one
                for (int i = 0; i < grRayCast.Count; i++)
                {
                    //Throw Raycast to all UI elements in the position(eventData)
                    grRayCast[i].Raycast(eventData, resultList);
                    sendArtificialUIEvent(grRayCast[i], eventData, evType);
                }
                //Reset Result
                resultList.Clear();
            }
    
            if (WholeScreenPointer.Instance.simulateCollider2DEvent)
            {
                //Loop Through All Collider 2D (Sprite Renderer) and throw Raycast to each one
                for (int i = 0; i < phy2dRayCast.Count; i++)
                {
                    //Throw Raycast to all UI elements in the position(eventData)
                    phy2dRayCast[i].Raycast(eventData, resultList);
                    sendArtificialUIEvent(phy2dRayCast[i], eventData, evType);
                }
                //Reset Result
                resultList.Clear();
            }
    
            if (WholeScreenPointer.Instance.simulateColliderEvent)
            {
                //Loop Through All Normal Collider(3D/Mesh Renderer) and throw Raycast to each one
                for (int i = 0; i < phyRayCast.Count; i++)
                {
                    //Throw Raycast to all UI elements in the position(eventData)
                    phyRayCast[i].Raycast(eventData, resultList);
                    sendArtificialUIEvent(phyRayCast[i], eventData, evType);
                }
                //Reset Result
                resultList.Clear();
            }
        }
    
        public void routeDragEvent(PointerEventData eventData)
        {
            routeOption(eventData, PointerEventType.Drag);
        }
    
        public void routePointerDownEvent(PointerEventData eventData)
        {
            routeOption(eventData, PointerEventType.Down);
        }
    
        public void routePointerUpEvent(PointerEventData eventData)
        {
            routeOption(eventData, PointerEventType.Up);
        }
    
        public void UpdateRaycaster()
        {
            convertToList(FindObjectsOfType<GraphicRaycaster>(), grRayCast);
            convertToList(FindObjectsOfType<Physics2DRaycaster>(), phy2dRayCast);
            convertToList(FindObjectsOfType<PhysicsRaycaster>(), phyRayCast);
        }
    
        //To avoid ToList() function
        void convertToList(GraphicRaycaster[] fromComponent, List<GraphicRaycaster> toComponent)
        {
            //Clear and copy new Data
            toComponent.Clear();
            for (int i = 0; i < fromComponent.Length; i++)
            {
                toComponent.Add(fromComponent[i]);
            }
        }
    
        //To avoid ToList() function
        void convertToList(Physics2DRaycaster[] fromComponent, List<Physics2DRaycaster> toComponent)
        {
            //Clear and copy new Data
            toComponent.Clear();
            for (int i = 0; i < fromComponent.Length; i++)
            {
                toComponent.Add(fromComponent[i]);
            }
        }
    
        //To avoid ToList() function
        void convertToList(PhysicsRaycaster[] fromComponent, List<PhysicsRaycaster> toComponent)
        {
            //Clear and copy new Data
            toComponent.Clear();
            for (int i = 0; i < fromComponent.Length; i++)
            {
                toComponent.Add(fromComponent[i]);
            }
        }
    
        //Checks if object is in the dictionary
        private bool dictContains(GameObject obj)
        {
            return pointerIdToGameObject.ContainsValue(obj);
        }
    
        //Checks if int is in the dictionary
        private bool dictContains(int pointerId)
        {
            return pointerIdToGameObject.ContainsKey(pointerId);
        }
    
        //Checks if int and object is in the dictionary
        private bool dictContains(int pointerId, GameObject obj)
        {
            return (pointerIdToGameObject.ContainsKey(pointerId) && pointerIdToGameObject.ContainsValue(obj));
        }
    
        //Adds pointerId and its value to dictionary
        private void dictAdd(int pointerId, GameObject obj)
        {
            pointerIdToGameObject.Add(pointerId, obj);
        }
    
        //Removes pointerId and its value from dictionary
        private void dictRemove(int pointerId)
        {
            pointerIdToGameObject.Remove(pointerId);
        }
    
        public enum PointerEventType
        {
            Drag, Down, Up
        }
    }
