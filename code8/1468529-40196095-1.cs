    System.Reflection.Assembly assembly = typeof(DynamicReportService).Assembly;
    var type = assembly.GetType(className);
    var storedProcedurePropertyInfo = type.GetProperty("StoredProcedure");
    var deafultValueAttribute = (DefaultValueAttribute) Attribute.GetCustomAttribute(storedProcedurePropertyInfo, typeof(DefaultValueAttribute)); 
    return deafultValueAttribute.Value.ToString();
