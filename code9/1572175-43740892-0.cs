    string actionName = ViewContext.RouteData.Values["Action"]
    MethodInfo method = type.GetMethod(actionName);
    var attribute = method.GetCustomAttributes(typeof(DisplayNameAttribute), false);
    if (attribute.Length > 0)
       actionName = ((DisplayNameAttribute)attribute[0]).DisplayName;
    else 
       actionName = type.Name;   // fallback to the type name of the controller
