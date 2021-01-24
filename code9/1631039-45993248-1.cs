    public float slowAmount;
    public float effectDuration = 3f;
    
    private Dictionary<GameObject, DragInfo> dragInfo = new Dictionary<GameObject, DragInfo>();
    
    //InteractiveObjectType
    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.GetComponent<InteractiveObjectType>() != null)
        {
            GameObject targetGo = coll.gameObject;
            Rigidbody targetRB = targetGo.GetComponent<Rigidbody>();
    
            DragInfo dragDetail = new DragInfo(targetRB.drag, targetRB.angularDrag);
    
            dragInfo.Add(targetGo, dragDetail);
        }
    
        //**// drag manipulation happens here**
    
    }
    
    void OnTriggerExit(Collider coll)
    {
        GameObject targetGo = coll.gameObject;
        Rigidbody targetRB = targetGo.GetComponent<Rigidbody>();
    
        if (coll.gameObject.GetComponent<InteractiveObjectType>() != null)
        {
            DragInfo storedDragInfo;
    
            //Check if the Object exist in the Dictiionry 
            if (dragInfo.TryGetValue(targetGo, out storedDragInfo))
            {
                //Restore the current value of the detected GameObject
                targetRB.drag = storedDragInfo.drag;
                targetRB.angularDrag = storedDragInfo.angularDrag;
                dragInfo.Remove(targetGo);
            }
        }
    }
