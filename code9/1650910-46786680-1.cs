    [Setup]
    public void SetupTest()
    {
        var field = typeof(TestClass).GetField("staticValue", BindingFlags.Static | BindingFlags.NonPublic);
        if(field != null)
            field.SetValue(null, 0);
    }
