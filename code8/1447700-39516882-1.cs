    foreach (var typeName in classes)
    {
         Type type = Type.GetType(typeName);
         var instance = Activator.CreateInstance(type);
    
         IEnumerable<WpfButton> myButtons = null;
         if(instance is MyBase) //MyBase is base class having virtual GetChildren() and this base class is derived by MyClass1, MyClass2...
         {
              myButtons = (instance as MyBase).GetChildren().OfType<WpfButton>();
         }
    }
