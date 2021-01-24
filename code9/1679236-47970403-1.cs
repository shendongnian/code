    List<dynamic> myObjects = new List<dynamic>();
    for(int i=0;i<5;i++)
    {
        dynamic obj = new ExpandoObject();
        //Add prop i property
        (obj as IDictionary<string, object>).Add("Prop"+i, "some value");
        //Remove prop i property
        (obj as IDictionary<string, object>).Remove("Prop"+i);
        //Add instead new property
        (obj as IDictionary<string, object>).Add("NewProp"+i, "some value");
        myObjects.Add(obj);
    }
