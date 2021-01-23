    FootnotesPart footnotesPart = doc.MainDocumentPart.FootnotesPart;
    if (footnotesPart != null)
    {
        var footnotes = footnotesPart.Footnotes.Elements<Footnote>();
        var references = doc.MainDocumentPart.Document.Body.Descendants<FootnoteReference>().ToArray();
        foreach (var footnote in footnotes)
        {
            long id = footnote.Id;
            var reference = references.Where(fr => (long)fr.Id == id).FirstOrDefault();
            if (reference != null)
            {
                Run run = reference.Parent as Run;
                reference.Remove();
                var fnText = string.Join("", footnote.Descendants<Run>().SelectMany(r => r.Elements<Text>()).Select(t => t.Text)).Trim();
                run.Parent.InsertAfter(new Run(new Text("(" + fnText + ")")), run);
            }
        }
    }
    doc.MainDocumentPart.Document.Save();
    doc.Close();
