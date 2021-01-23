    private Control FindControl(string ctlToFindId, Control parentControl)
    {
        foreach (Control ctl in parentControl.Controls)
        {
            if (ctl.Id == ctlToFindId)
                return ctl;
        }
    
        if (ctl.Controls != null)
        {
            var c = FindControl(ctlToFindId, ctl);
            if (c != null) return c;
        }
    
        return null;
    }
