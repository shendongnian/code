        var columnIndices = new List<Tuple<int,int>>();
        var colCounter = 0;
        foreach (var col in myDataGrid.Columns)
        {
            columnIndices.Add(Tuple.Create(col.DisplayIndex, colCounter));
            colCounter += 1;
        }
        var sortedColumns = columnIndices.OrderBy(x => x.Item1).ToList();        
