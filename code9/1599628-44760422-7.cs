	private Stream CreatePdf()
	{
		using (var document = new Document(PageSize.A4, 50, 50, 25, 25))
		{
			var output = new MemoryStream();
			var writer = PdfWriter.GetInstance(document, output);
			writer.CloseStream = false;
			document.Open();
			document.Add(new Paragraph("Hello World"));
			document.Close();
			output.Seek(0, SeekOrigin.Begin);
			return output;
		}
	}
