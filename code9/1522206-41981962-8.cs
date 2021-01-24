        PdfPTable table = new PdfPTable(colNum);
        foreach (string line in content.Split('\n'))
        {
            foreach (string cellstr in line.Split(','))
            {
                PdfPCell cell = new PdfPCell(new Phrase(cellstr));
                table.AddCell(cell);
            }
        }
        AddParagraph(doc, iTextSharp.text.Element.ALIGN_CENTER, _largeFont, table);
