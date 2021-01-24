    public RectTransform uiRect1;
    public RectTransform uiRect2;
    
    void Update()
    {
        if (rectOverlaps(uiRect1, uiRect2))
        {
            Debug.Log("Overlaps");
        }else
        {
            Debug.Log("Does not Overlap");
        }
    }
