    for (int i = 0; i < datagridview.Rows.Count; i++)
    {
        var sourceFolder = @"E:\scan\" + datagridview.Rows[i].Cells[0].Value;
        var destinationFoler = @"E:\scan\" + datagridview.Rows[i].Cells[1].Value;
        if (Directory.Exists(sourceFolder))
        {
            Directory.Move(sourceFolder, destinationFolder);
        }
        else
        {
            // Warn the user. E.g.
            // MessageBox.Display("Directory not found.");
        }
    }
