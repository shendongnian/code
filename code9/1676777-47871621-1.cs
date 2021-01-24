    private static bool IsWpfApplication2() {
        var wpfAsm = AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(c => c.GetName().Name == "PresentationFramework"); 
        if (wpfAsm == null)
            return false;
        var type = wpfAsm.GetType("System.Windows.Application");
        if (type == null)
            return false;
        var currentProp = type.GetProperty("Current", BindingFlags.Public | BindingFlags.Static);
        if (currentProp == null)
            return false;
        return currentProp.GetValue(null, new object[0]) != null;
    }
