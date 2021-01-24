    StreamWriter file = null;
    try
    {
        try
        {
            file = new StreamWriter(path);
        }
        catch (Exception ex) //unable to create file
        {
            MessageBox.Show("Cannot create file");
            return;
        }
        file.WriteLine("hello world!");
    }
    finally
    {
        if (file != null)
        {
            file.Dispose();
        }
    }
