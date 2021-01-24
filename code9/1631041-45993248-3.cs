    public struct DragInfo
    {
        public float drag;
        public float angularDrag;
    
        //Initialize the variables
        public DragInfo(float drag, float angularDrag)
        {
            this.drag = drag;
            this.angularDrag = angularDrag;
        }
    }
    
    public float slowAmount;
    public float effectDuration = 3f;
    
    private Dictionary<GameObject, DragInfo> dragInfo = new Dictionary<GameObject, DragInfo>();
    
    void OnTriggerEnter(Collider coll)
    {
        Rigidbody targetRB;
    
        if (coll.gameObject.GetComponent<InteractiveObjectType>() != null)
        {
            GameObject targetGo = coll.gameObject;
            targetRB = targetGo.GetComponent<Rigidbody>();
    
            //Create new DragInfo with the current Object 
            DragInfo dragDetail = new DragInfo(targetRB.drag, targetRB.angularDrag);
    
            //Add it to the Dictionary
            dragInfo.Add(targetGo, dragDetail);
        }
    
        //drag manipulation happens here**
        //targetRB.drag = ???
        //targetRB.angularDrag = ???
    }
    
    void OnTriggerExit(Collider coll)
    {
        GameObject targetGo = coll.gameObject;
        Rigidbody targetRB = targetGo.GetComponent<Rigidbody>();
    
        if (coll.gameObject.GetComponent<InteractiveObjectType>() != null)
        {
            //Where to store retrieved Object
            DragInfo storedDragInfo;
    
            //Retrieve and Check if the Object exist in the Dictiionry 
            if (dragInfo.TryGetValue(targetGo, out storedDragInfo))
            {
                //Restore the current value of the detected GameObject
                targetRB.drag = storedDragInfo.drag;
                targetRB.angularDrag = storedDragInfo.angularDrag;
    
                //Remove it from the Dictionary
                dragInfo.Remove(targetGo);
            }
        }
    }
