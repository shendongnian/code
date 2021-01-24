    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [RefreshProperties(System.ComponentModel.RefreshProperties.All)]
    public string Style 
    {
        get 
        {
            if (Control != null)
                return Control.Style;
            else
                return null;
        }
        set 
        {
            if (Control != null)
                Control.Style = value;
        }
    }
