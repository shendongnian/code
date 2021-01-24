    foreach (var v in TC.GetType().GetMembers())
    {
        if (v is PropertyInfo)
        {
           var value = ((PropertyInfo)v).GetValue(TC, null);
           TCValues.Add(value);
        }
        else if (v is FieldInfo)
        {
           var value = ((FieldInfo) v).GetValue(TC);
           TCValues.Add(value);
        }
    }
