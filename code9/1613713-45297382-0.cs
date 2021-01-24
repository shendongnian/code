    // names you want to search for
    string[] searchForNames = new string[] { "Propeller1" , "Propeller2" , "Propeller3" , "Propeller4" };
    
    // list of objects that matches the search
    List<GameObject> wantedObjects = new List<GameObject>();
    // placeholder for all objects in the current scent
    List<GameObject> allObjects = new List<GameObjects>();
    // retrieve all objects from active scene ( wont retrieve objects marked with DontDestroyOnLoad from other scenes )
    SceneManager.GetActiveScene()GetRootGameObjects( allObjects );
    // iterate through all objects found in the current scene
    foreach(GameObject obj in allObjects)
    {
        // check if name is contained by searchForNames array
        if(searchForNames.Contains(obj.name))
        {
            // add to the matching list
            wantedObjects.Add(obj);
        }
    }
