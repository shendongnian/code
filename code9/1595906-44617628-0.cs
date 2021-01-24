    [System.Serializable]
    public class IntUnityEvent : UnityEvent<int>
    {
        public int intParam;
    }
    
    public IntUnityEvent uIntEvent;
    
    void Start()
    {
        //Create the parameter to pass to the function
        if (uIntEvent == null)
            uIntEvent = new IntUnityEvent();
    
        //Add the function to call
        uIntEvent.AddListener(ActivateQuest);
        //Set the parameter value to use
        uIntEvent.intParam = 2;
    
        //Pass the IntUnityEvent/UnityAction to a function
        PopulateConversationList(uIntEvent);
    }
    
    public void PopulateConversationList(IntUnityEvent action)
    {
        //Test/Call the function 
        action.Invoke(action.intParam);
    }
    
    //The function to call
    public void ActivateQuest(int questId)
    {
        Debug.Log("This is the id: " + questId);
    }
