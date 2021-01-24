    Texture2D tex;
    
    void Start () 
    {
        tex = new Texture2D(200, 300, TextureFormat.RGB24, false);
    }
    
    void Update () 
    {
        if (stream != null)
        {
            tex.LoadImage(stream.ToArray());
            ....
            ...
        }
    }
