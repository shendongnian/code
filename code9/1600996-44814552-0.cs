    var item1 = new KeyTestClass(); 
    var item2 = Substitute.For<IKeyTestClass>();
    var item3 = Substitute.For<IKeyTestClass>();
    item2.Id.Returns(1);
    item3.Id.Returns(42);
    Assert.IsTrue(item1.Equals(item2)); // Passes (as expected)
    Assert.IsFalse(item1.Equals(item3)); // Passes (as expected)
