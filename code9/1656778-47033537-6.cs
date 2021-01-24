    string nameOfAssetBundle = "animals";
    string nameOfObjectToLoad = "dog";
    
    public RawImage image; 
    void Start()
    {
        StartCoroutine(LoadAsset(nameOfAssetBundle, nameOfObjectToLoad));
    }
