    public GameObject prefab;
    
    void Start()
    {
        //Create new Cube
        GameObject obj = Instantiate(prefab);
        obj.name = "Cube001";
    
        //Add it to the Dictionary
        registerObject(obj, delegate { Debug.Log("Hit: " + obj.name); });
    }
