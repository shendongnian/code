    List<string> theData = new List<string>();
    string s;
    while ((s = sr.ReadLine()) != null)
    {
        if (!String.IsNullOrEmpty(s))
        {
            if (s[0] == '$')
            {
                theData.Add(s);
                if (s.Contains("GPGGA"))
                {
                    myData.Add(new DataSet(theData)); //you're passing your source by reference.
                    theData.Clear();
                    Console.WriteLine();
                }
            }
        }
    }
