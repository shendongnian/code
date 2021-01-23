    foreach (DataRow row in dt.Rows)
    {
        if(row["x"] == DBNull.Value || string.IsNullOrWhiteSpace(row["x"].ToString())
        {
            continue;
        }
        
        var actualPDF = row["x"].ToString();
        var namedFN = row["y"].ToString();
        var fileID = row["z"].ToString();
        var filesinFolder = listBox2.Items.ToString();
        listBox1.Items.Add(fileID);
        listBox4.Items.Add(namedFN);
        
        oldNames.Add(actualPDF);
    }
