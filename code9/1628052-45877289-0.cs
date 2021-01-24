    using (var mock = AutoMock.GetLoose())
    {
        mock.Provide<CloudBlobContainer, CloudBlobContainer>(new NamedParameter("uri", new Uri("your uri")));
        var mockClient = mock.Mock<CloudBlobClient>();
    }
