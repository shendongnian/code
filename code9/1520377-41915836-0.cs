    from row in Table
        group row by new
        {
            row.ColumnA,
            row.ColumnB,
            ...
            ...
        } into gcs
        select new {
            ColumnA = gcs.Key.ColumnA,
            ColumnB = gcs.Key.ColumnB,
            ...
            ...
        };
