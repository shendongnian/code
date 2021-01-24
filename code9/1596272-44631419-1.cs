    const string TYPENAME = "System.Action";
    Type objType = obj.GetType();
    if(objType.ToString().StartsWith(TYPENAME)) // it is Action
    {
        Type[] genericArguments = objType.GetGenericArguments();
        object[] parameters = new object[genericArguments.Length];
        // fill your parameters
        
        (obj as MulticastDelegate).DynamicInvoke(params object[] args);
    }
