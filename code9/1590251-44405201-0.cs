    foreach (string i in __file)
    {
        if (File.Exists(i))
        {
            FileInfo fajl = new FileInfo(i);
            Console.WriteLine("{0},{1},{2}", fajl.Name, fajl.Extension, fajl.LastWriteTime.ToString());
        }
    }
    
