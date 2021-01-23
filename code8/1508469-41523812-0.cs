    public Material skybox;
    public Color afterColor = Color.white;
    
    // Use this for initialization
    public void Start()
    {
        skybox = RenderSettings.skybox;
        skybox.SetColor("_Color3", afterColor); //here
    }
