            const string FILENAME = @"c:\temp\test.txt";
            static void Main(string[] args)
            {
                Dictionary<int, Dictionary<string, int>> dict = new Dictionary<int, Dictionary<string, int>>();
                StreamReader reader = new StreamReader(FILENAME);
                string input = "";
                while ((input = reader.ReadLine()) != null)
                {
                    //string input = "11=205129022,453=8,448=CompanyID,447=D,452=63,448=userid,447=D,452=11,448=CompanyName,447=D,452=13,448=W,447=D,452=54,77=O,555=2";
                    List<string> strArray = input.Split(new char[] { ',' }).ToList();
                    //or dictionary
                    Dictionary<string, int> rowDict = strArray.Select(x => x.Split(new char[] { '=' })).GroupBy(x => x.Last(), y => int.Parse(y.First())).ToDictionary(x => x.Key, y => y.FirstOrDefault());
                    int id = rowDict["CompanyID"];
                    dict.Add(id, rowDict);
                }
            }
