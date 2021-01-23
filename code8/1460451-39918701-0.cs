    using (TextWriter Tw = new StreamWriter(outputFile))
    {
        foreach (String s in ListData)
        {
            Tw.WriteLine(s);             
        }
    }
