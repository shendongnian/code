    public static void PropertyValuesAreEquals<T>(object actual, object expected)
    {
        Assert.IsTrue(actual is T);
        Assert.IsTrue(expected is T);
        foreach (var property in typeof(T).GetProperties().Where(o => o.CanRead))
        {
            var expectedValue = property.GetValue(actual, null);
            var actualValue = property.GetValue(expected, null);
            ...
        }
    }
