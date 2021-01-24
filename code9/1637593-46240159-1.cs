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
        var dupRowNumList = articleLookup[article].Select(x => x.RowNum).ToList();
        string dupRowNumText = dupRowNumList.Count == 1 ? "" : String.Join(",", dupRowNumList);
        addedRow.SetField("Article", article);
        addedRow.SetField("Duplicates", dupRowNumText);
    }
