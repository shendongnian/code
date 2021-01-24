    [Test]
    public void GDerivedTestOfSomeProperty()
    {
        // arrange
        ParamOfSomeProperty expected = ValueWeAreLookingFor; // this is something that you
                                                             // have in newCalculatedValue
        // act
        GDerived actual = new GDerived(
            AnyValueThatMakesThisTestWork1, // maybe null?
            AnyValueThatMakesThisTestWork2); // maybe null?
        // assert
        Assert.AreEqual(expected, actual.SomeProperty);
    }
