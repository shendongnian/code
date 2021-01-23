    string currentLine;
        
    using (StreamReader sr = new StreamReader(filePath))
    {
        while ((currentLine = sr.ReadLine()) != null)
        {
            if (currentLine == "line 4")
            {
                Console.WriteLine("line exist");
            }
            else
            {
                Console.WriteLine("line does not exist");
            }
        }
    }
