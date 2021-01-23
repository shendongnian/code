    private void filesAndTemplates()
    {
        string path = @"\\directoryname\foldername";
        HashSet<string> files = new HashSet<string>();
        try
        {
            DirectoryInfo dinfo = new DirectoryInfo(label2.Text);
            FileInfo[] Files = dinfo.GetFiles("*.doc");
            foreach (FileInfo file in Files)
            {
                files.Add(file.Name);
                listView1.Items.Add(file.Name);
            }
            dinfo = new DirectoryInfo(path);
            Files = dinfo.GetFiles("*.doc");
            foreach (FileInfo file in Files)
            {
                if (files.Contains(file.Name))
                {
                    continue; // We already saw this file
                }
                listView2.Items.Add(file.Name);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
