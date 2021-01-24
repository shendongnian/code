    foreach (string i in __file)
    {
        try
        {
            FileInfo fajl = new FileInfo(i);
            Console.WriteLine("{0},{1},{2}", fajl.Name, fajl.Extension, fajl.LastWriteTime.ToString());
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
            throw;
        }
        
    }
