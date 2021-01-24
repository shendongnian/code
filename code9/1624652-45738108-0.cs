    private static void TabelWithBorderTest()
    {
        var document = new Document();
    
        // Add a section to the document.
        var section = document.AddSection();
    
        Table table = section.AddTable();
        table.Borders.Width = 0.25;
        table.Rows.LeftIndent = 0;
    
        // Before you can add a row, you must define the columns
        Column column = table.AddColumn("7cm");
        column.Format.Alignment = ParagraphAlignment.Left;
    
        Row row = table.AddRow();
        row.Cells[0].AddParagraph("Text in table");
    
        // Create a renderer for the MigraDoc document.
        var pdfRenderer = new PdfDocumentRenderer(false) { Document = document };
    
        // Associate the MigraDoc document with a renderer.
    
        // Layout and render document to PDF.
        pdfRenderer.RenderDocument();
    
        // Save the document...
        const string filename = "TableTest.pdf";
        pdfRenderer.PdfDocument.Save(filename);
        // ...and start a viewer.
        Process.Start(filename);
    }
