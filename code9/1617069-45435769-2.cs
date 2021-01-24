    [TestCase(null)]
    [TestCase("")]
    public void ShouldThrowArgumentException(string path)
    {
        Assert.That(() => _import.LoadBatchFile(path), Throws.TypeOf<ArgumentNullException>());
    }
