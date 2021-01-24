    void InitializeHierarchy(Transform root)
    {
        var initializable = root.GetComponent<Initializable>();
        if(initializable != null) initializable.Initialize();
        foreach(Transform t in root)
        {
            if(t == root) continue;  //make sure you don't initialize the existing transform
            InitializeHierarchy(t); //initialize this Transform's children recursively
        }
    }
