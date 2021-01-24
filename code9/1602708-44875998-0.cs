    StringBuilder sb = new StringBuilder();
    var options = new PdfTextExtractionOptions
                    {
                        WithFormatting = false,
                        SkipInvisibleText = true
                    };
    using (PdfDocument pdf = new PdfDocument("document.pdf"))
    {
        foreach(var page in pdf.Pages)
        {
            sb.AppendLine(page.GetText(options));
	    }
    }
    string allText = sb.ToString();
