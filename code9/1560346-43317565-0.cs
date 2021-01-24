	private static Image GetPageImage(int pageNumber, Size size, PdfiumViewer.PdfDocument document, int dpi)
	{
		return document.Render(pageNumber - 1, size.Width, size.Height, dpi, dpi, PdfRenderFlags.Annotations);
	}
	
	private void RenderPage(string pdfPath, int pageNumber, Size size, string outputPath)
	{
		using (var document = PdfiumViewer.PdfDocument.Load(pdfPath))
		using (var stream = new FileStream(outputPath, FileMode.Create))
		using (var image = GetPageImage(pageNumber, size, document, 150))
		{
			image.Save(stream, ImageFormat.Jpeg);
		}
	}
