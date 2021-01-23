    private int CreateTOC(XmlNode xmlNode, Document doc, PdfWriter writer, int number, int level) {
        var toc = ev.GetTOC();
        KeyValuePair<string, int> value;
        Chunk dottedLine = new Chunk(new iTextSharp.text.pdf.draw.DottedLineSeparator());
        for (int i = 0; i < xmlNode.ChildNodes.Count; i++)
        {
            var text = xmlNode.ChildNodes[i].Attributes["text"].Value;
            value = toc[text];
            var dest = value.Key;
            var page = value.Value;
            var c = new Chunk((i+1).ToString()+ ". " + text, font);
            c.SetAction(PdfAction.GotoLocalPage(dest, false));
            var p = new Paragraph(c);
            p.IndentationLeft = 10 * level;
            p.Add(dottedLine);
            c = new Chunk(page.ToString(), font);
            c.SetAction(PdfAction.GotoLocalPage(dest, false));
            p.Add(c);
            doc.Add(p);
            CreateTOC(xmlNode.ChildNodes[i], doc, writer, i+1, level + 1);
        }
        return writer.PageNumber;
    }
