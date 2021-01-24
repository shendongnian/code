    public void Test(string type, string json)
    {
        Type type = Type.GetType($"MyNamespace.a.b.{type}, MyDll");
        // from all method named "DeserializeObject"
        // find the one that is generic method
        MethodInfo deserializeObjectMethodInfo = typeof(JsonConvert)
            .GetMethods(BindingFlags.Static | BindingFlags.Public)
            .FirstOrDefault(m => m.IsGenericMethod && m.Name == "DeserializeObject");
        // create a specialized method for the requested type
        // same as you would call DeserializeObject<type>
        MethodInfo specializedDeserializeObject = deserializeObjectMethodInfo.MakeGenericMethod(type);
        // invoke that method with json as parameter
        // and cast it to IData
        IData data = (IData)specializedDeserializeObject.Invoke(null, json);
        // do whatever you want with the deserialized object
        data.DoSomething("bazinga");
    }
