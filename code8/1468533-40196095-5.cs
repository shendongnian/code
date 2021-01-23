    System.Reflection.Assembly assembly = typeof(DynamicReportService).Assembly;
    var type = assembly.GetType(className);
    var storedProcedurePropertyInfo = type.GetProperty("StoredProcedure"); 
    var defaultValueAttribute = storedProcedurePropertyInfo.GetCustomAttribute<DefaultValueA‌​ttribute>();
    return defaultValueAttribute.Value.ToString();
