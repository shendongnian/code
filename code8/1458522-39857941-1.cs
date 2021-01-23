    var actual = test.Validate("0");
    Assert.IsTrue(actual.IsValid);
    actual = test.Validate("foo");
    Assert.IsFalse(actual.IsValid);
    // Repeat ad nauseum with different values
