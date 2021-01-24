    DataTable dt = new DataTable("File Size");
    dt.Columns.Add("Name");
    dt.Columns.Add("Size");// could be dt.Columns.Add("Size", typeof(long))
    DirectoryInfo save = new DirectoryInfo(@"C:\Save\");
    if (save.Exists)
    {
        foreach (var dir in save.GetDirectories())
        {
            var row = dt.NewRow();
            row["Name"] = dir.FullName.TrimEnd('\\');
            // If you want to count also files in subfolders cahnge false to true 
            // If you add column with long type, calling ToString() will not be necessary
            row["Size"] = GetDirSize(dir, false);
            dt.Rows.Add(row);
        }    
    }
