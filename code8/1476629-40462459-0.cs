    var names = new List<string>();
    var lastnames = new List<string>();
    var text = File.ReadAllLines(@"C:\Users\Jal\Desktop\Test.text");
    foreach (var s in text)
    {
        if (s.Contains("name"))
        {        
            var name = s.Substring(s.IndexOf("=") + 1);
            names.Add(desc);
        }
        if (s.Contains("lastname"))
        {        
            var lastname = s.Substring(s.IndexOf("=") + 1);
            lastnames.Add(desc);
        }
    }
