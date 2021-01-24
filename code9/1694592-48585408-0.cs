    // create baspath for the search
    string basepath = Path.Combine(Application.StartupPath, "Stock", "171457");
    // getting the files form th OS
    string[] allfiles = System.IO.Directory.GetFiles(basepath, "*.pdf", System.IO.SearchOption.AllDirectories);
    // security check, since it will open all files
    if (MessageBox.Show($"You are going to open {allfiles.Count()} files. Continue?","",MessageBoxButtons.OKCancel) == DialogResult.OK)
    {
        foreach (var item in allfiles)
        {
            System.Diagnostics.Process.Start(item);
        }
    }
