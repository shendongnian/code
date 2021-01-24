    foreach(var row in myTable)
    {
        if (token.IsCancellationRequested)
        {
            break;
        }
        //else continue with processing
        var line=String.Join(",", row.ItemArray);
        writer.WriteLine(line);
    }
