    [Test]
    public void TestProbeStopTest()
    {
        var probe = CreateTestProbe("Test");
        Watch(probe.Ref);
        Sys.Stop(probe.Ref);
        ExpectTerminated(probe.Ref);
    }
