    if (Enum.GetNames(typeof(SpecialIds)).Contains(message.id))
    {
        //special behavior
        string id = message.Id.ToString();
        string prefix = "Special_";
        string className = prefix + id;
    
        Type t = Type.GetType(className);
        ConstructorInfo constructor = t.GetConstructor(new Type[] { message.GetType() });
        constructor.Invoke(message);
    }
