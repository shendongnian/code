    [TestCaseSource("StuffSets")]
    public void ToThings_Always_ThrowsAnException(List<Stuff> set)
    {
        // Arrange
        // Whatever you need to do here...
        // Act
        ActualValueDelegate<object> test = () => Transform.ToThings(set);
        // Assert
        Assert.That(test, Throws.TypeOf<SomeKindOfException>());
    }
    public static IEnumerable<List<Stuff>> StuffSets = 
    {
        get 
        {
            return new[] { 0, 1, 2 }
                .Select(_ => Enumerable.Repeat(new Stuff(_), _).ToList())
                .ToList();
        }
    };
