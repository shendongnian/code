    using (var fs = File.Open(specificFolder, FileMode.OpenOrCreate, FileAccess.ReadWrite))
    {
        using (var sw = new StreamWriter(fs))
        {
            sw.WriteLine(Username.Text);
        }
    }
