    var string1 = "Hello World";
    var name = "World";
    var string2 = "Hello " + name;
    Assert.AreSame(string1, string2); //Will return false
    Assert.IsTrue(object.ReferenceEquals(string1,string2)); // Fail
    Assert.AreEqual(string1, string2); // Pass
