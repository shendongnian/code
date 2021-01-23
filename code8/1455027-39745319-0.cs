    PropertyInfo[] props = typeof(MemberModel).GetProperties();
    foreach (PropertyInfo prop in props)
    {
        if (prop.Name != "Password")
            customPrincipal.GetType().GetProperty(prop.Name).SetValue(customPrincipal, serializeModel.GetType().GetProperty(prop.Name).GetValue(memberModel, null) as string);
    }
