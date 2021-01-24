    using (StreamReader inputStream = new StreamReader(filepath, System.Text.Encoding.UTF8))
    {
        string line;
        while ((line = inputStream.ReadLine()) != null)
        {
            Console.WriteLine(line);                  
        }
    }
