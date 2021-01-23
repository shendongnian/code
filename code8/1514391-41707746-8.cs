     interface IGenericClass<out T>
     {
     }
     class GenericClass<T> : IGenericClass<T>
     {
     }
     IGenericClass<Child> gcChild = new GenericClass<Child>();
     IGenericClass<Parent> gcParent = gcChild; // This is allowed!
     var l = new List<IGenericClass<Parent>>();
     l.Add(new GenericClass<Child>()); // Also allowed
    
