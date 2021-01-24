    public static class GridViewRowExtensions
    {
       public static TControl Returncontrol<TControl>(this GridViewRow gvr, String ControlName) where TControl : Control
       {
            TControl control = gvr.FindControl(ControlName) as TControl;
    
            return control;
       }
    }
