    public static bool GetControlStyle(Control control, ControlStyles flags)
    {
        Type type = control.GetType();
        BindingFlags bindingFlags = BindingFlags.NonPublic | BindingFlags.Instance;
        MethodInfo method = type.GetMethod("GetStyle", bindingFlags);
        object[] param = { flags };
        return (bool)method.Invoke(control, param);
    }
   
