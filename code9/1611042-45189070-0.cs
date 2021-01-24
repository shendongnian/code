    Type colorType = typeof(System.Drawing.Color);
    
    PropertyInfo[] propInfoList = colorType.GetProperties(BindingFlags.Static | BindingFlags.DeclaredOnly | BindingFlags.Public);
    
    var colorNames = propInfoList.Select(c => c.Name);
