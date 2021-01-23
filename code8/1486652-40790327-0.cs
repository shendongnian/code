    [Test]
    public void TestNullableBooleanTrue()
    {
        bool? b = true;
        Assert.That(b, Is.True);
    }
    [Test]
    public void TestNullableBooleanFalse()
    {
        bool? b = false;
        Assert.That(b, Is.False);
    }
    [Test]
    public void TestNullableBooleanNull()
    {
        bool? b = null;
        Assert.That(b, Is.Null);
    }
