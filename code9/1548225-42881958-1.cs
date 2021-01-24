    try
    {
        var fs = File.Open(specificFolder, FileMode.OpenOrCreate, FileAccess.ReadWrite);
        try
        {
            var sw = new StreamWriter(fs);
            sw.WriteLine(Username.Text);
        }
        finally
        {
            sw.Dispose();
        }
    }
    finally
    {
        fs.Dispose();
    }
