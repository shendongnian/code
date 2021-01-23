    var attributes = TestClass.GetType().GetCustomAttributes(typeof(ProtoContract), true);
    if(attributes.Length < 1)
        return; //we don't have the attribute
    var attribute = attributes[0] as ProtoContract;
    if(attribute != null)
    {
       //access the attribute as needed
    }
