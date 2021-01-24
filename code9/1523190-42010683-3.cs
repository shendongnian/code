    Console.WriteLine("METHOD 1");
    
    var records = new List<string>();
    
    using (var fs = new FileStream("d:\\SampleData.txt", FileMode.Open))
    {
        using (var rdr = new StreamReader(fs))
        {
            var msgFound = false;
            while (!rdr.EndOfStream)
            {
                var tempreadline = rdr.ReadLine();
                if (tempreadline.Contains("MESSAGE"))
                {
                    msgFound = true;
                }
                else if (msgFound && !string.IsNullOrEmpty(tempreadline))
                {
                    records.Add(tempreadline);
                    msgFound = false;
                }
            }
        }
    }
    
    records.ForEach(r => Console.WriteLine(r));
    
