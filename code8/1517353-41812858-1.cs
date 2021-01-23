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
                        List<string> bindingdata = theData.ToList();
                        myData.Add(new DataSet(bindingData)); //you're passing
                        //your source by value, because it's using a new list.
                        theData.Clear(); //you can now safely do this.
                        Console.WriteLine();
                    }
                }
            }
        }
