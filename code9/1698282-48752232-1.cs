    //The list of the Objects to check if they appeared x amount of time
    public List<GameObject> testList;
    //The specific Object to check 
    public GameObject objToCheck;
    //The X amount of time it should check if it appeared
    int specificCount = 3;
    
    void Start()
    {
        bool result = listConstainsSpecificObjCount(testList, objToCheck, specificCount);
        Debug.Log(result);
    }
