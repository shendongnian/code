    [Test]
    public void TestProcuctAndCategory(
        [Values("ProductA", ProductB")] string productName,
        [Values("Cat1", "Cat2", "Cat3")] string category)
    {
        // Test will be executed six times, using all combinations
        // of the values provided for the two arguments.
    }
