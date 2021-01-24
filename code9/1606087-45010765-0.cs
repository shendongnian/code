    public static void InsertTextBoxAtEachPage()
    {
        string filePathIn = MyDir + @"input.docx";
        string filePathOut = MyDir + @"output.docx";
    
        Document doc = new Document(filePathIn);
    
        DocumentBuilder builder = new DocumentBuilder(doc);
        LayoutCollector collector = new LayoutCollector(doc);
    
        int pageIndex = 1;
        foreach (Section section in doc.Sections)
        {
            NodeCollection paragraphs = section.Body.GetChildNodes(NodeType.Paragraph, true);
            foreach (Paragraph para in paragraphs)
            {
                if (collector.GetStartPageIndex(para) == pageIndex)
                {
                    builder.MoveToParagraph(paragraphs.IndexOf(para), 0);
                    builder.StartBookmark("BM_Page" + pageIndex);
                    builder.EndBookmark("BM_Page" + pageIndex);
                    pageIndex++;
                }
            }
        }
    
        collector = new LayoutCollector(doc);
        LayoutEnumerator layoutEnumerator = new LayoutEnumerator(doc);
    
        const int PageRelativeY = 0;
        const int PageRelativeX = 0;
    
        foreach (Bookmark bookmark in doc.Range.Bookmarks)
        {
            if (bookmark.Name.StartsWith("BM_"))
            {
                Paragraph para = (Paragraph)bookmark.BookmarkStart.ParentNode;
    
                Shape textbox = new Shape(doc, Aspose.Words.Drawing.ShapeType.TextBox);
    
                textbox.Top = PageRelativeY;
                textbox.Left = PageRelativeX;
    
                int currentPageNumber = collector.GetStartPageIndex(para);
    
                string barcodeString = string.Format("page {0} of {1}", currentPageNumber, doc.PageCount);
                string barcodeEncodedString = "some barcode string";
    
                Paragraph paragraph = new Paragraph(doc);
                ParagraphFormat paragraphFormat = paragraph.ParagraphFormat;
                paragraphFormat.Alignment = ParagraphAlignment.Center;
                Aspose.Words.Style paragraphStyle = paragraphFormat.Style;
                Aspose.Words.Font font = paragraphStyle.Font;
                font.Name = "Tahoma";
                font.Size = 12;
                paragraph.AppendChild(new Run(doc, barcodeEncodedString));
                textbox.AppendChild(paragraph);
    
                paragraph = new Paragraph(doc);
                paragraphFormat = paragraph.ParagraphFormat;
                paragraphFormat.Alignment = ParagraphAlignment.Center;
    
                paragraphStyle = paragraphFormat.Style;
                font = paragraphStyle.Font;
                font.Name = "Arial";
                font.Size = 10;
                paragraph.AppendChild(new Run(doc, barcodeString));
                textbox.AppendChild(paragraph);
    
                //Set the width height according to your requirements
                textbox.Width = doc.FirstSection.PageSetup.PageWidth;
                textbox.Height = 50;
                textbox.BehindText = false;
    
                para.AppendChild(textbox);
    
                textbox.RelativeHorizontalPosition = Aspose.Words.Drawing.RelativeHorizontalPosition.Page;
                textbox.RelativeVerticalPosition = Aspose.Words.Drawing.RelativeVerticalPosition.Page;
    
                bool isInCell = bookmark.BookmarkStart.GetAncestor(NodeType.Cell) != null;
                if (isInCell)
                {
                    var renderObject = collector.GetEntity(bookmark.BookmarkStart);
                    layoutEnumerator.Current = renderObject;
    
                    layoutEnumerator.MoveParent(LayoutEntityType.Cell);
                    RectangleF location = layoutEnumerator.Rectangle;
    
                    textbox.Top = PageRelativeY - location.Y;
                    textbox.Left = PageRelativeX - location.X;
                }
            }
        }
    
        doc.Save(filePathOut, SaveFormat.Docx);
    }
