    public readonly static BindableProperty WidthRatioProperty =
                BindableProperty.Create("WidthRatio",
                typeof(float),
                typeof(MyMasterDetailPage),
                (float)0.2);
    
    public float WidthRatio
    {
        get
        {
            return (float)GetValue(WidthRatioProperty);
        }
        set
        {
            SetValue(WidthRatioProperty, value);
        }
    }
