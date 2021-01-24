    List<Action> mExecutionQueue;
    List<Action> mUpdateQueue;
    public void Update()
    {
        lock (mExecutionQueue)
        {
            mUpdateQueue.AddRange(mExecutionQueue);
            mExecutionQueue.Clear();
        }
        foreach (var action in mUpdateQueue) // todo: time limit, only perform ~10ms of actions per frame
        {
            try {
                action();
            }
            catch (System.Exception e) {
                UnityEngine.Debug.LogError("Exception in UnityMainThreadDispatcher: " + e.ToString());
            }
        }
        mUpdateQueue.Clear();
    }
        
    public void Enqueue(Action action)
    {
        lock (mExecutionQueue)
            mExecutionQueue.Add(action);
    }
