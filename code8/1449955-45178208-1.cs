    [Theory]
    [MemberData(SomeTypeScenario)]
    public void TestMethod(Type type) {
      Assert.Equal(typeof(double), type);
    }
    
    public static IEnumerable<object[]> SomeScenario() {
      yield return new object[] { typeof(double) };
    }
