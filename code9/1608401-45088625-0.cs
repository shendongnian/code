	private MemoryStream createDocument(Table customTable)
	{
		var stream = new MemoryStream();
		// Create a Wordprocessing document. 
		using (WordprocessingDocument package = WordprocessingDocument.Create(stream, WordprocessingDocumentType.Document))
		{
			// Add a new main document part. 
			package.AddMainDocumentPart();
			// Create the Document DOM. 
			package.MainDocumentPart.Document =
			  new Document(
				new Body(
				  new Paragraph(
					new Run(
					  new Table(customTable)))));
			// Save changes to the main document part. 
			package.MainDocumentPart.Document.Save();
		}
		stream.Seek(0, SeekOrigin.Begin);
		return stream;
	}
