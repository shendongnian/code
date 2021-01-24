    using FluentAssertions;
    
    //...
    
    // Example 1
    AMockObject a = new AMockObject();
    AMockObject b = new AMockObject();
    a.ShouldBeEquivalentTo(b); // Asserts that an object is equivalent to another object.
    
    // Example 2
    AMockObject a = new AMockObject() { Id = 1 };
    AMockObject b = new AMockObject() { Id = 1 };
    a.ShouldBeEquivalentTo(b); //Asserts that an object is equivalent to another object.
    
    // Example 3
    AMockObject a = new AMockObject() { Id = 1 };
    a.Numbers.Add(1);
    a.Numbers.Add(2);
    a.Numbers.Add(3);    
    AMockObject b = new AMockObject() { Id = 1 };
    b.Numbers.Add(1);
    b.Numbers.Add(2);
    b.Numbers.Add(3);    
    a.ShouldAllBeEquivalentTo(b); // Asserts that a collection of objects is equivalent to another collection of objects.
