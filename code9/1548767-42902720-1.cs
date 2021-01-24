    using (Document document = new Document()) {
        PdfWriter writer = PdfWriter.GetInstance(document, stream);
        document.Open();
        // Draw first-page-only header
        ColumnText ct = new ColumnText(writer.DirectContent);
        XMLWorkerHelper.GetInstance().ParseXHtml(new ColumnTextElementHandler(ct), new StringReader(html));
        ct.SetSimpleColumn(document.Left, document.Top, document.Right, document.GetTop(-PDFMarginTop), 0, Element.ALIGN_MIDDLE);
        ct.Go();
        // Draw document content
        [Add some content to document]
    }
