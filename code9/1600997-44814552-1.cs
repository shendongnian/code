    var item1 = Substitute.For<IKeyTestClass>();
    var item2 = Substitute.For<IKeyTestClass>();
    item1.Id.Returns(1);
    item2.Id.Returns(1);
    item1.Equals(item2).Returns(true);
    Assert.IsTrue(item1.Equals(item2)); // Passes as expected
