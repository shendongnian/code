    protected TControl Returncontrol<TControl>(GridViewRow gvr, String ControlName) 
                                                                      where TControl : Control
    {
        TControl control = gvr.FindControl(ControlName) as TControl;
        
        return control;
    }
