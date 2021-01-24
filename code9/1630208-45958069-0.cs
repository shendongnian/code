    var interfaceType = typeof(IInterface);
    var interfaceVar = typeof(Class).GetInterface(interfaceType.Name);
    var returnMethod = interfaceVar.GetMethods().FirstOrDefault(m 
             =>m.ReturnType.IsSubclassOf("MyMember") || m.ReturnType == "MyMember");
     if(returnMethod != null){
      // your member is implementation of interface
       }
