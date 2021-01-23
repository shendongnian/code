    List<Parent> l = new List<Parent>();
    l.Add(new Child());  // A child can be converted to a Parent, this is OK
     
    List<GenericClass<Parent>> gl = new List<GenericClass<Parent>>();
    gl.Add(new GenericClass<Child>()); // A GenericClass<Child> does not convert to GenericClass<Parent>, so this is not allowed.
