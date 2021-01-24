    foreach (var type in value)
    {
        var item = type.Value;
        var newstring = item.GetType().GetMethod("ReturnValue").Invoke(null, new object[] { }).ToString(); ////// GetType() of Type
        newletter = letter.Replace(type.Key, newstring);
    }
