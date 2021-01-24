    [Test]
    public void DoesDownloadGetTheCorrectValue()
    {
        //This implementation is up to you
        var downloadedString = GetFileFromAWSSomehow();
        Assert.AreEqual(downloadedString, StringToTestWith);
    }
