    foreach (TableCell cell in GridView6.HeaderRow.Cells)
    {
        if (cell.Text == "&nbsp;")
        {
            dt.Columns.Add(Guid.NewGuid().ToString()); //just some random value, i use guid, you can use anything you like to keep it unique.
        }
        else
        {
            dt.Columns.Add(cell.Text);
        }
    }
