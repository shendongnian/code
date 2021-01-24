    List<dynamic> myObjects = new List<dynamic>();
    for (int i = 0; i < 5; i++)
    {
        dynamic obj = new ExpandoObject();
        obj.MyProperty = "some value";
        obj.ChangePropertyName = "change property name";
        myObjects.Add(obj);
    }
