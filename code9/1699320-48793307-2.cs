    var privateObject = new PrivateObject(new SomeObjectWithInAccessibleMembers());
    privateObject.SetField("_someInstanceField", 1);
    Assert.AreEqual(1, privateObject.GetField("_someInstanceField"));
    var privateType = new PrivateType(typeof(SomeObjectWithInAccessibleMembers));
    privateType.SetStaticField("_someStaticField", 1);
    Assert.AreEqual(1, privateType.GetStaticField("_someStaticField"));
