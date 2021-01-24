    public static void Test(SomeObject model)
    {
        // Only changes which object in memory "model" points to.
        // The original object outside of this method is unchanged.
        // There are now two objects in memory.
        model = new SomeObject();
    }
    public static void Test(SomeObject model)
    {
        // There's still only one object in memory.
        // The object which was passed to this method sees the change.
        model.SomeProperty = someValue;
    }
