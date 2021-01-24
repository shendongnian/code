    if (DesignerProperties.GetIsInDesignMode(someDepenencyObject))
    {
        LoadDesignTimeData();
    }
    else
    {
        LoadRealData();
    }
