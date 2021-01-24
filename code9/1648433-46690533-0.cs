    public Texture2D yourTeture;
    public GameObject plane;
    
    void Start()
    {
        MeshRenderer meshRenderer = plane.GetComponent<MeshRenderer>();
        meshRenderer.material.mainTexture = yourTeture;
    }
