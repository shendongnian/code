    String text = "<p>Hello <strong>world</strong>!</p>";
    List<IElement> parsedText = ConvertToHtmlForColumnText(text);
    using (Document document = new Document(PageSize.A4))
    {
        PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(result, FileMode.Create));
        document.Open();
        ColumnText ct = new ColumnText(writer.DirectContent);
        ct.SetSimpleColumn(document.Left, document.Bottom, document.Right, document.Top);
        ct.Add(parsedText);
        ct.Go();
    }
