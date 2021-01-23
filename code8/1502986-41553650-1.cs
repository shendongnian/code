    using (PdfReader reader = new PdfReader(filename))
    {
        for (int page = 1; page <= reader.NumberOfPages; page ++)
        {
            String text = PdfTextExtractor.GetTextFromPage(reader, page, new TagFilteringExtractionStrategy());
            Console.Write("\n=======\nPage {0}\n=======\n{1}\n", page, text);
        }
    }
