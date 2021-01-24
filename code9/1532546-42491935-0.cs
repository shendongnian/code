    TestClass test;
    try
    {
    test = new TestClass();
    }
    finally
    {
    if(test != null)
          test.Dispose();
    }
