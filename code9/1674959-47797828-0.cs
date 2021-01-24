    private void DgridQueryResults_ColumnSetup()
    {
        DgridQueryResults.Columns.Clear();
        DgridQueryResults.AutoGenerateColumns = false;
        foreach (DataColumn column in _results.Columns)
        {
            var gridColumn = new DataGridTextColumn()
            {
                Header = column.ColumnName,
                SortMemberPath = column.ColumnName, //<--added
                Binding = new Binding("[" + column.ColumnName + "]")
            };
            DgridQueryResults.Columns.Add(gridColumn);
        }
    }
