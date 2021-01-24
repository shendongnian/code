    private bool _Feature1Enabled;
    public bool Feature1Enabled
    {
        get { return _Feature1Enabled; }
        set
        {
            _Feature1Enabled = value;
            OnPropertiesChanged("Feature1Enabled");
            OnPropertiesChanged("AllFeatures");
        }
    }
    
    private bool _Using_Feat_1;
    public bool Using_Feat_1
    {
        get { return _Using_Feat_1; }
        set
        {
            _Using_Feat_1 = value;
            OnPropertiesChanged("Using_Feat_1");
            OnPropertiesChanged("AllFeatures");
        }
    }
    // more properties...
