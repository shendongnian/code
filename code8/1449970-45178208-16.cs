    [GenericMethod(new Type[] { typeof(double), typeof(int) })]
    public void TestGeneric<T>()
    {
      Assert.Equal(typeof(T), typeof(double));
    }
