    List<string> classes = new List<string> { "WindowsFormsApplication1.MyClass1", "WindowsFormsApplication1.MyClass2" };
    foreach (var typeName in classes)
    {
         Type type = Type.GetType(typeName);
         var instance = Activator.CreateInstance(type);
    
         var result = (type.GetMethod("GetChildren").Invoke(instance, null) as IEnumerable<object>).OfType<WpfButton>();
         
    }
