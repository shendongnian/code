	private PdfDocument FormatPdfDocument(PdfDocument document, List<string> packingTypes, string carrierName)
	{
		XFont PackingTypeFont = new XFont("Calibri", 10, XFontStyle.Bold);
		var i = 0;
		foreach (PdfPage page in document.Pages)
		{
			using (var gfx = XGraphics.FromPdfPage(page))
			{
				var packingType = packingTypes.ElementAtOrDefault(i++) ?? "PackingType Not Found";
				if (carrierName == "xxxx")
				{
					var packingTypeBounds = new XRect(64, 62, 200, 12);
					gfx.DrawRectangle(XBrushes.White, packingTypeBounds);
					gfx.DrawString(packingType, PackingTypeFont, XBrushes.Black, packingTypeBounds, XStringFormats.TopLeft);
					var logoBounds = new XRect(0, 0, 130, 50);
					gfx.DrawRectangle(XBrushes.White, logoBounds);
				}
				else if (carrierName == "yyyy")
				{
					var packingTypeBounds = new XRect(200, 0, 200, 12);
					gfx.DrawString(packingType, PackingTypeFont, XBrushes.Black, packingTypeBounds, XStringFormats.TopLeft);
				}
				else if (carrierName == "zzzz")
				{
					var packingTypeBounds = new XRect(410, 20, 200, 12);
					var state = gfx.Save();
					gfx.RotateAtTransform(90, new XPoint { X = 410, Y = 20 });
					gfx.DrawString(packingType, PackingTypeFont, XBrushes.Black, packingTypeBounds, XStringFormats.TopLeft);
					gfx.Restore(state);
				}
			}
		}    
		return document;
	}
