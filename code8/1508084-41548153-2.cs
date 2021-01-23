    public void StopTest()
    { 
        var t = CreateTestActor("AAAA");
        Watch(t);
        Sys.Stop(t);
        ExpectTerminated(t, TimeSpan.FromSeconds(10));
        var t2 = CreateTestActor("AAAA"); // test fails here
    }
