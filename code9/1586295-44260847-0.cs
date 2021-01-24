    public Cubemap c;
    private Color[] CubeMapColors;
    public Texture2D t;
    void Start() 
    {
        CubeMapColors = t.GetPixels();
        c.SetPixels(CubeMapColors, CubemapFace.PositiveX);
        c.Apply();
    }
