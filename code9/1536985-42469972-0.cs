    var newRow = dt2.NewRow();  //dt2 is the destination table. Creating new row for destination table.
    for (var i = 0;i < dt2.Columns.Count;i++)
    {
        var row1 = dt1.Rows[i];
        newRow[i] = row1[0];
    }
    dt2.Rows.Add(newRow); //Adding new row to the destination table.
 
    var xRow = dt2.Rows[0]; //Retrieving row for displaying the data to Console.
    for (var j = 0; j < dt2.Columns.Count; j++)
    {
        Console.WriteLine(xRow[j]);
    }
