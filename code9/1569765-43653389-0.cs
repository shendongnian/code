    foreach (var v in TC.GetType().GetMembers())
    {
        if (v.MemberType == System.Reflection.MemberTypes.Property)
        {
            TCValues.Add(((System.Reflection.PropertyInfo)v).GetValue(TC,null)); 
        }
        else if (v.MemberType == System.Reflection.MemberTypes.Field)
        {
            TCValues.Add(((System.Reflection.FieldInfo)v).GetValue(TC));
        }
    }
