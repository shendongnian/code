    string cellValue = null;
    
    string headingText = "My Heading Text";
    int rowIndex = 0;
    int columnIndex = 0;
    
    // Load Word document.
    DocumentModel document = DocumentModel.Load("Sample.docx");
    
    // Iterate through all paragraphs.
    foreach (Paragraph paragraph in document.GetChildElements(true, ElementType.Paragraph))
    {
        // Check that paragraph is of heading style.
        ParagraphStyle style = paragraph.ParagraphFormat.Style;
        if (style == null || !style.Name.Contains("heading"))
            continue;
    
        // Check that heading paragraph contains our text.
        if (!paragraph.Content.ToString().Contains(headingText))
            continue;
    
        // Get first table after the heading paragraph.
        Table table = new ContentRange(paragraph.Content.End, document.Content.End)
            .GetChildElements(ElementType.Table)
            .Cast<Table>()
            .First();
    
        // Get cell value.
        cellValue = table.Rows[rowIndex].Cells[columnIndex].Content.ToString();
        break;
    }
    
    Console.WriteLine(cellValue);
