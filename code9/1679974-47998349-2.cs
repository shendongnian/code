    using (StreamReader sr = new StreamReader(@"S:\Personal Folders\A\TESTA.txt"))
    {
        using (StreamWriter sw = new StreamWriter(@"S:\Personal Folders\A\TESTB.txt"))
        {
            while ((string line = sr.ReadLine())!= null)
            {
                sw.WriteLine(line.Replace("before", "after"));
            }
        }
    }
