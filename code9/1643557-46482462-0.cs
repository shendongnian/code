    List<GameObject> objList = new List<GameObject>();
    
    void instantiateObj(GameObject obj)
    {
        GameObject newInstance = Instantiate(obj);
    
        //Add to list
        objList.Add(newInstance);
    }
    
    void destroyObj(GameObject obj)
    {
        Destroy(obj);
    
        //Remove from list
        objList.Remove(obj);
    }
