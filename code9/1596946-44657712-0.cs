    File.CreateText(pathToLoad)).Dispose();
    using (TextWriter writer = new StreamWriter(pathToLoad, false))
    {
        writer.WriteLine("00:00:00,00/00/0000,1,1,500,20000,1500,50,20,10,5,2,1,1,0,10,50,50");
        writer.Close();
    }
