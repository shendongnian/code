    string a = @"
    <table>
      <row>
        <cell>Hello 1-1</cell>
        <cell>Hello 1-2</cell>
      </row>
      <row>
        <cell>Hello 2-1</cell>
        <cell>Hello 2-2</cell>
      </row>
    </table>";
    XmlDocument xmlDocument = new XmlDocument();
    xmlDocument.LoadXml(a.Substring(a.IndexOf(Environment.NewLine)));
    XmlWriterSettings settings = new XmlWriterSettings() {  Indent = true };
    XmlWriter writer = XmlWriter.Create("data.xml", settings);
    xmlDocument.Save(writer);
    ComponentInfo.SetLicense("FREE-LIMITED-KEY");
    DocumentModel pdfDocument = new DocumentModel();
    Table table = new Table(pdfDocument);
    table.TableFormat.PreferredWidth = new TableWidth(100, TableWidthUnit.Percentage);
    pdfDocument.Sections.Add(new Section(pdfDocument, table));
    foreach (XmlNode xmlRow in xmlDocument.SelectNodes("/table/row"))
    {
        TableRow row = new TableRow(pdfDocument);
        table.Rows.Add(row);
        foreach (XmlNode xmlCell in xmlRow.SelectNodes(".//cell"))
            row.Cells.Add(
                new TableCell(pdfDocument,
                    new Paragraph(pdfDocument, xmlCell.InnerText)));
    }
    pdfDocument.Save("sample.pdf");
