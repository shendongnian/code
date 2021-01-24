    StringBuilder sb = new StringBuilder();
    var options = new PdfTextExtractionOptions
                    {
                        WithFormatting = false,
                        SkipInvisibleText = true
                    };
    using (PdfDocument pdf = new PdfDocument("document.pdf"))
    {
        int pageIndex = 1;
        foreach(var page in pdf.Pages)
        {
            Console.WriteLine("Page {0}", pageIndex++);
            sb.AppendLine(page.GetText(options));
	    }
    }
    string allText = sb.ToString();
