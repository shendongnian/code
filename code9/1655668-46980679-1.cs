    [Test]
    public override void SomeTest()
    {
        // Run some logic to determine if the test should be skipped.
        bool skipThisTest = true;
        Assume.That(skipThisTest, "This test doesn't apply here.");
    }
