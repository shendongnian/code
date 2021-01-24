    string[] ogcontent = {"f", "red", "frs", "xyr", "frefff", "xdd", "to"};
        string lineData = "";
        int lineIndex = 0;
        for (int i = 0; i < ogcontent.Length; i++)
        {
            string line = ogcontent[i];
            var index = i;
            if (line.Contains("x"))
            {
                lineData = line;
                lineIndex = index; 
				Console.WriteLine("index = {0}", i);
				Console.WriteLine("value = {0}", line);
                break;
            }
        }
