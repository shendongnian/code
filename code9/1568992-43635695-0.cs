    Action<GameObject, GameState, GameObject, Vector3> onCutCB;
    
    void OnCut(GameObject survivalObj, GameState state, GameObject
    destroyObj, Vector3 startPos = default(Vector3))
    {
    
    }
    
    void Start()
    {
        //MEMORY IS ALLOCATION
        onCutCB = OnCut;
    }
    
    void Update()
    {
        //NO MEMORY ALLOCATION HERE
        onCutCB(objToUse, gameState, anotherObj, thePos);
    }
