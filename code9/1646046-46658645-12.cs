    static void Main(string[] args)
    {
        var source = Package.Open(@"test.docx");
        var document = WordprocessingDocument.Open(source);
        HtmlConverterSettings settings = new HtmlConverterSettings();
        XElement html = HtmlConverter.ConvertToHtml(document, settings);
    
        Console.WriteLine(html.ToString());
        var writer = File.CreateText("test.html");
        writer.WriteLine(html.ToString());
        writer.Dispose();
        Console.ReadLine();
