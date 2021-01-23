    List<string> dataSet = new List<string>();
    string s;
    while ((s = sr.ReadLine()) != null)
    {
        if (!String.IsNullOrEmpty(s))
        {
            if (s[0] == '$')
            {
                dataSet.Add(s);
                if (s.Contains("GPGGA"))
                {
                    myData.Add(new DataSet(dataSet.ToList()));
                    dataSet.Clear();
                    Console.WriteLine();
                }
            }
        }
    }
