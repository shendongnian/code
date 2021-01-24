    var grouped = (
        from row in dt.AsEnumerable()
        group row by row.Field<int>("ID") into g
        select g
    );
    foreach (var grp in grouped)
    {
        Console.WriteLine("ID = {0}", grp.Key);
        foreach (var row in grp)
        {
            // Logic - row will be the DataRow
        }
    }
