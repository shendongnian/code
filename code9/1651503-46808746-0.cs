    [Test]
    public void TestOne(
        [ValueSource(nameof(Formats))] string format, 
        [ValueSource(typeof(DocumentFactory), nameof(DocumentFactory.Documents))] IDocument document)
    {
            document.Should().NotBeNull();
    }
