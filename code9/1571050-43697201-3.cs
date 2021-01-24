    Dictionary<int, GameObject> idToObj = new Dictionary<int, GameObject>();
    
    Tile[] tiles = new Tile[1000];
    GameObject obj = new GameObject("obj");
    
    //Create new Instance with Instance ID
    tiles[0] = new Tile(obj.GetInstanceID());
    
    //Add to Dictionary
    idToObj.Add(obj.GetInstanceID(), obj);
