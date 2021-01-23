    public static DataSet HtmlTablesToDataset(string html)
    {
        var resultDataset = new DataSet();
        HtmlDocument doc = new HtmlDocument();
        doc.LoadHtml(html);
        foreach (HtmlNode table in doc.DocumentNode.SelectNodes("//table"))
        {
            var resultTable = new DataTable(table.Id);
            foreach (HtmlNode row in table.SelectNodes("tr"))
            {
                var headerCells = row.SelectNodes("th");
                if (headerCells != null)
                {
                    foreach (HtmlNode cell in headerCells)
                    {
                        resultTable.Columns.Add(cell.InnerText);
                    }
                }
                var dataCells = row.SelectNodes("td");
                if (dataCells != null)
                {
                    var dataRow = resultTable.NewRow();
                    for (int i=0; i < dataCells.Count; i++)
                    {
                        dataRow[i] = dataCells[i].InnerText;
                    }
                    resultTable.Rows.Add(dataRow);
                }
            }
            resultDataset.Tables.Add(resultTable);
        }
        return resultDataset;
    }
