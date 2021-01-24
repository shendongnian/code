    using System.Reflection;
    MethodInfo clearCachedData = typeof(TimeZoneInfo).GetMethod("ClearCachedData", 
       BindingFlags.NonPublic | BindingFlags.Static);
    if (clearCachedData != null)
    {
        clearCachedData.Invoke(null, null);
    }
