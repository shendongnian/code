    public POIButton()
    {
        InitializeComponent();
        var visual = ElementCompositionPreview.GetElementVisual(this);
        visual.Clip = visual.Compositor.CreateInsetClip();
    }
