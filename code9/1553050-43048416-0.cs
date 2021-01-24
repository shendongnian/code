    List<DataTable> dtCollection = dt.AsEnumerable()
                       .Where(row => row.RowState != DataRowState.Deleted)
                       .GroupBy(row => row.Field<string>("Printers"))
                       .Select(g => g.CopyToDataTable())
                       .ToList();
