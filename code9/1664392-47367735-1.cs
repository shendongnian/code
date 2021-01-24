    private UnityAction unityAction;
    
    void Start()
    {
        unityAction = stringFunctionToUnityAction(this, "hello");
        unityAction.Invoke();
    }
    //Function to call
    void hello()
    {
        Debug.Log("Hello");
    }
