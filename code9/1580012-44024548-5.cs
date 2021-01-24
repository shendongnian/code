    byte[] somedata = new byte[10];
    TestClass tc = TestClass.CreateIfValidData(somedata);
    if (tc != null)  
    {
        // only if the object was constructed, use it
    }
    else 
    {
        // oops something went wrong...
    }
