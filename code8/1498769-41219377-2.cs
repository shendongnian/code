    public GameObject canvas;
    void Start()
    {
        DefaultControls.Resources uiResources = new DefaultControls.Resources();
        //Set the Slider Background Image someBgSprite;
        uiResources.background = someBgSprite;
        //Set the Slider Fill Image someFillSprite;
        uiResources.standard = someFillSprite;
        //Set the Slider Knob Image someKnobSprite;
        uiResources.knob = someKnobSprite;
        GameObject uiSlider = DefaultControls.CreateSlider(uiResources);
        uiSlider.transform.SetParent(canvas.transform, false);
    }
