    [Test]
    public void NullString()
    {
        Assert.That(() => new SecurityToken(null), Throws.Exception.TypeOf<NullReferenceException>());
    }
