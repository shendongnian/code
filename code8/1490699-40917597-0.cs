    if (System.IO.Directory.Exists(dirName))
    {
        string filePath = Path.Combine(dirName, fileName);
        if (System.IO.File.Exists(filePath))
        {
            System.IO.File.Delete(filePath);
        }
    
        else
        {
            MessageBox.Show("Invalid Directory or File Name");
        }
    }
