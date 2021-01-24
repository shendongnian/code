    using Services;
    ...
    public CustomClass LocalVariable
    {
        get { return GlobalVars.aGlobalVariable; }
        set 
        {
            GlobalVars.aGlobalVariable = value;
            ...
        }
    }
    //refresh purpose
    public void refresh()
    {
        RaisePropertyChanged(() => LocalVariable);
    }
