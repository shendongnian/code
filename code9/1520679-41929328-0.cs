     string line = "";
            Dictionary<string, int> list = new Dictionary<string, int>();
            int count;
            if (File.Exists(fileName) == true)
            {
                StreamReader objReader;
                objReader = new StreamReader(fileName);
                StreamWriter file = new StreamWriter(OutputfileName");
                do
                {
                    line = objReader.ReadLine();
                    string temp = line.Substring(0, 10);
                    if (!list.ContainsKey(temp))
                    {
                        MatchCollection collection = Regex.Matches(line, @"D;");
                        count = collection.Count;
                        list.Add(temp, count);
                    }
                    else
                    {
                        MatchCollection collection = Regex.Matches(line, @"D;");
                        count = collection.Count;
                        var val = list[temp];
                        list[temp] = count + val;
                    }
                } while (objReader.Peek() != -1);
                foreach (var j in list)
                {
                    file.WriteLine(j.Key + "  -  " + j.Value+"\n");
                }
                file.Close();
            }
