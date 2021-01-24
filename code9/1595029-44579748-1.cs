                string[][] toMerge = {
                    new string[] {"School", "Train", "Bag", "Choclate", " ", " "}, 
                    new string[] {"College", " ", " " , "chicken", " ", " "},
                    new string[] {"work", "car", " ", "Burger", " ", " "}
                                      };
                List<string> results = new List<string>();
                for (int i = 0; i < toMerge.First().Count(); i++)
                {
                    string min = toMerge.Where(x => x[i].Trim().Length > 0).Select(x => x[i]).Min();
                    results.Add(min == null ? " " : min);
                }
                Console.WriteLine(string.Join(",",results));
                Console.ReadLine();
