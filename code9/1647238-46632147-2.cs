    private bool _stackPanelVis;
    public bool StackPanelVis 
    { 
        get { return _stackPanelVis; } 
        set {
            if (value == _stackPanelVis) return;
            _stackPanelVis = value;
            OnProperyChanged("StackPanelVis");
        }
    }
