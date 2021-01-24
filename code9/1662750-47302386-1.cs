    try
    {
        DoSomething();
    }
    catch(NullReferenceException) { Assert.Pass(); }
    catch(KeyNotFoundException) { Assert.Pass(); }
    catch(InvalidOperationException) { Assert.Pass(); }
    catch(Exception) { Assert.Fail("Unexpected exception was caught"); }
    Assert.Fail("No exception was caught");
