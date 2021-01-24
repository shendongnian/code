    using (System.IO.StreamReader sr = new System.IO.StreamReader(filePath))
    {
        string line;
        while ((line = sr.ReadLine()) != null)
        {
            //..
        }
    }
