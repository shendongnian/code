    private static bool IsWpfApplication() {
        var type = Type.GetType("System.Windows.Application, PresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35");
        if (type == null)
            return false;
        var currentProp = type.GetProperty("Current", BindingFlags.Public | BindingFlags.Static);
        if (currentProp == null)
            return false;
        return currentProp.GetValue(null, new object[0]) != null;
    }
