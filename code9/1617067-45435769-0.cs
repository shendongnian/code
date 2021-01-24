    [TestCase(null)]
    [TestCase("")]
    public void ShouldThrowArgumentException(string path)
    {
        // Act
        ActualValueDelegate<object> testDelegate = () => _import.LoadBatchFile(path);
        // Assert
        Assert.That(testDelegate, Throws.TypeOf<ArgumentNullException>());
    }
