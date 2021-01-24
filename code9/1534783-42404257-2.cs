    #if DEBUG
        var info = foo.GetType().GetMethod("GetDebuggingInfo", BindingFlags.Instance | BindingFlags.Public);
        if (info != null)
        {
            var text = (string)info.Invoke(foo, null);
            messageBuilder.AppendLine(text);
        } 
    #endif
