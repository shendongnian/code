    private const string StringToTestWith = "some sort of test string goes in here";
    [Test]
    public void UploadFileToAWS()
    {
        // Arrange
        var bucket = "bucketName";
        var keyName = "test_upload.txt";
        var uploadFile = GenerateStreamFromString(StringToTestWith);
        // Act
        var aws = new AmazonWebServicesUtility(bucket);
        var awsUpload = aws.UploadFile(keyName, uploadFile);
        // Assert
        Assert.AreEqual(true, awsUpload);
    }
    private static Stream GenerateStreamFromString(string s)
    {
        var stream = new MemoryStream();
        var writer = new StreamWriter(stream);
        writer.Write(s);
        writer.Flush();
        stream.Position = 0;
        return stream;
    }
