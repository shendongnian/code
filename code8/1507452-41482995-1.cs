    FieldInfo subField = Group.GetType().GetField("sub");
    // get the value of the "sub" field of the current group
    object subValue = subField.GetValue(Group);
    foreach (PropertyInfo property in subField.FieldType.GetProperties(bindingFlags))
    {
        string strName = property.Name;
        Console.WriteLine(strName + " = " + property.GetValue(subValue, null).ToString());    
    }
