    public static class GridViewRowExtensions
    {
       public static TControl Returncontrol<TControl>(this GridViewRow gvr, String ControlName)
       {
            TControl control = gvr.FindControl(ControlName) as TControl;
    
            return control;
       }
    }
