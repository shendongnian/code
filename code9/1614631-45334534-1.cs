    private void Edit_Config(string data)
    {
        using (var writer = new StreamWriter(file_loc, true))
        {
           writer.WriteLine(data);
        }
    }
                  
