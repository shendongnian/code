    public static void PropertyValuesAreEquals<T>(object actual, object expected)
    {
        Assert.IsTrue(actual is T);
        Assert.IsTrue(expected is T);
        foreach (var property in typeof(T).GetProperties().Where(o => o.CanRead))
        {
            var actualValue = property.GetValue(actual, null);
            var expectedValue = property.GetValue(expected, null);
            ...
        }
    }
