    [TestCase(null, typeof(ArgumentNullException))]
    [TestCase("", typeof(ArgumentException))]
    [TestCase(" ", typeof(ArgumentException))]
    [TestCase(" \t \t ", typeof(ArgumentException))]
    [TestCase("< !!!>", typeof(FileNotFoundException))]
    public void InvalidFilePath_ThrowsException(string name, Type exceptionType) 
    {
        Dictionary<string, string> dict = new Dictionary<string, string>();    
        Assert.Throws(exceptionType, () => ModelFactory.Current.CreateDocument(name, dict));
    }
