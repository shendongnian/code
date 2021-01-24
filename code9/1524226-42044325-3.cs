    public RectTransform uiRect1;
    public RectTransform uiRect2;
    
    void Update()
    {
        if (uiRect1.rectOverlaps(uiRect2))
        {
    
        }
    
        //OR
    
        if (uiRect2.rectOverlaps(uiRect1))
        {
    
        }
    }
