        var rows = dsFirst.Tables[0].Rows;
        var newRows = dsNew.Tables[0].Rows;
        // Choose your collection type here...
        var forBinding = new List<object>();
        for (int i = rows.Count - 1; i < newRows.Count; i++)
        {
            forBinding.Add(newRows[i]);
        }
        
        dataGrid.DataSource = forBinding;
