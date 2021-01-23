    System.Reflection.Assembly assembly = typeof(DynamicReportService).Assembly;
    var type = assembly.GetType(className);
    var storedProcedurePropertyInfo = type.GetProperty("StoredProcedure"); 
    var deafultValueAttribute storedProcedurePropertyInfo.GetCustomAttribute<DefaultValueA‌​ttribute>();
    return deafultValueAttribute.Value.ToString();
