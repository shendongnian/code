    PdfPTable table = new PdfPTable(7);
    for (int i= 0;i<res.Length;i++)
    {
        List<String> col = new List<String>();
        foreach (string line in res[i].ToString().Split('|'))
        {
            table.AddCell(new Phrase(line));
        }
    }
    document.Add(table);
