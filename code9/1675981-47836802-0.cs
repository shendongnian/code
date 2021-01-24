           public static void readCells()
            {
                var dictionary = new Dictionary<string, List<List<string>>>();
                Console.WriteLine("started");
                var counter = 1;
                var readText = File.ReadAllLines(path);
                var duplicatedValues = dictionary.GroupBy(fullName => fullName.Value).Where(fullName => fullName.Count() > 1);
                foreach (var s in readText)
                {
                    List<string> values = s.Split(new Char[] { ',' }).ToList();
                    string fullName = values[3];
                    if (!dictionary.ContainsKey(fullName))
                    {
                        List<List<string>> newList = new List<List<string>>();
                        newList.Add(values);
                        dictionary.Add(fullName, newList);
                    }
                    else
                    {
                        dictionary[fullName].Add(values);
                    }
                    Console.WriteLine("Full Name Is: " + values[3]);
                    counter++;
                }
            }
