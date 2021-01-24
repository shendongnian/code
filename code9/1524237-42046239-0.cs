    Dictionary<int, MoveInfo> movingObject = new Dictionary<int, MoveInfo>();
    
    public void Move(Transform from, Transform to, float overTime)
    {
        MoveInfo moveInfo;
    
        //Check if the Object exist in the Dictionay
        if (movingObject.TryGetValue(from.GetInstanceID(), out moveInfo))
        {
            //This Object exist and therefore, the coroutine function is already running. Stop it
    
            //Remove it from the Dictionary
            movingObject.Remove(from.GetInstanceID());
    
            //Stop the old coroutine
            StopCoroutine(moveInfo.currentCoroutine);
        }
    
        //Create a new coroutine
        moveInfo = createMoveInfoInstance(from);
    
        //Add it to the dictionary 
        movingObject.Add(from.GetInstanceID(), moveInfo);
    
        //Get instance of the new coroutine we are about to start
        moveInfo.currentCoroutine = _Move(moveInfo, from, to, overTime);
    
        //Modify the dictionary because the Add function does not update the currentCoroutine reference
        movingObject[from.GetInstanceID()] = moveInfo;
    
        //Start the coroutine
        StartCoroutine(moveInfo.currentCoroutine);
    }
    
    MoveInfo createMoveInfoInstance(Transform from)
    {
        MoveInfo moveInfo = new MoveInfo();
        moveInfo.instanceID = from.GetInstanceID();
        return moveInfo;
    }
    
    IEnumerator _Move(MoveInfo moveInfo, Transform from, Transform to, float overTime)
    {
        Vector2 original = from.position;
        float timer = 0.0f;
    
        Debug.Log("New Coroutine Started");
        while (timer < overTime)
        {
            float step = Vector2.Distance(original, to.position) * (Time.deltaTime / overTime);
            from.position = Vector2.MoveTowards(from.position, to.position, step);
            timer += Time.deltaTime;
            yield return null;
        }
    
        //Remove it from the Dictionary if it exist
        if (movingObject.ContainsKey(from.GetInstanceID()))
        {
            movingObject.Remove(from.GetInstanceID());
        }
    }
    
    public struct MoveInfo
    {
        public IEnumerator currentCoroutine;
        public int instanceID;
    
        public MoveInfo(IEnumerator currentCoroutine, int instanceID)
        {
            this.currentCoroutine = currentCoroutine;
            this.instanceID = instanceID;
        }
    }
