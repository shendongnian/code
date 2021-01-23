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
                    {   //we don't need this now.
                        //List<string> bindingdata = theData.ToList();
    //make myData a DataSet so you can use datatables
    // instead of attempting IEnumerable<DataSet>
                        
                        DataTable foo = new DataTable("Foo");                               
                        foreach(string s in theData)
                        { 
                            var y = foo.NewRow();
                            y[0] = s;
                            foo.Rows.Add(y);
                        }
                        myData.Add(foo);                                
                        theData.Clear(); //you can now safely do this.
                        Console.WriteLine();
                    }
                }
            }
        }
