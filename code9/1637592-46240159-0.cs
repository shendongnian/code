    var articleLookup = yourTable.AsEnumerable()
        .Select((row, index) => new { Row = row, RowNum = index + 1 })
        .ToLookup(x=> x.Row.Field<string>("Article"));
    
    DataTable dupTable = new DataTable();
    dupTable.Columns.Add("Article");
    dupTable.Columns.Add("Duplicates");
    
    foreach(DataRow row in yourTable.Rows)
    {
        DataRow addedRow = dupTable.Rows.Add();
        string article = row.Field<string>("Article");
        string duplicates = String.Join(",", articleLookup[article].Select(x => x.RowNum));
        addedRow.SetField("Article", article);
        addedRow.SetField("Duplicates", duplicates);
    }
