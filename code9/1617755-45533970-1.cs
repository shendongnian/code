    AllLines = new string[MAX]; //only allocate memory here
    using (StreamReader sr = File.OpenText(fileName))
    {
        int x = 0;
        while (!sr.EndOfStream)
        {
               AllLines[x] = sr.ReadLine();
               x += 1;
        }
    } // The using will dispose of any resources.
