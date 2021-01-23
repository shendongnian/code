    public Renderer objeto1;
    public Renderer objeto2;
    public Renderer objeto3;
    bool enabled = false;
    void OnMouseDown() 
    {
        objeto1.enabled = enabled;
        objeto2.enabled = enabled;
        objeto3.enabled = enabled;
        enabled = !enabled;
    }
