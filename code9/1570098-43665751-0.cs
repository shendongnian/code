    string[] FileContents = File.ReadAllLines(@"c:\slovardata.txt");
     Dictionary<string, string> dict = new Dictionary<string, string>();
     KeyValuePair<string, string> kvp;
     foreach (string line in FileContents)
        {
           var keyvalue = Regex.Match(line, @"(.*)=(.*)");
           dict.Add(keyvalue.Groups[1].Value, keyvalue.Groups[2].Value);
        }
     foreach (var item in dict)
        {
           Console.WriteLine("Key : " + item.Key + "\tValue : " + item.Value);
        }
