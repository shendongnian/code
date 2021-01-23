    [Test]
    public void should_extract_from_pdf()
    {
    var textExtractionResult = new TextExtractor().Extract("Tika.pdf");
     
    textExtractionResult.Text.ShouldContain("pack of pickled almonds");
     
    Console.WriteLine(textExtractionResult);
    }
