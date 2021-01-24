    Test Testobj = new Test();
    // Find the fields for Testobj.
    Type myType = typeof(Test);
    FieldInfo[] fields = myType.GetFields();
    for(int i = 0; i < fields.Length; i++)
    {
        // Get value for field.
        var myValue = fields[i].GetValue(Testobj);
    }
