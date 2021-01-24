    // Camera cam1;
    // Camera cam2;
    
    void Update()
    {
        bool isVisibleForCamera1 = cam1.IsObjectVisible(GetComponent<MeshRenderer>());
        bool isVisibleForCamera2 = cam2.IsObjectVisible(GetCoponent<SpriteRenderer>());
    }
