    private void OnChanged(object sender, FileSystemEventArgs e)
    {
        string destFolder = Path.Combine(@"d:\", comboBox1.SelectedItem.ToString());
        if (!Directory.Exists(destFolder))
        {
            Directory.CreateDirectory(destFolder);
        }
        string destFileName = Path.Combine(destFolder, new FileInfo(e.FullPath).Name);
        try
        {
            File.Move(e.FullPath, destFileName);
        }
        catch (Exception ex)
        {
            Console.WriteLine("File move operation error:" + ex.Message);
        }
    }
