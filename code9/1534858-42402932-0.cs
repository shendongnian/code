     var revList = new List<string>  { "A", "NC", "New", "AB", "PD", "PD1",
                                          "PD2", "B", "-", "*", "BB", "NA" };
            
            revList = revList.OrderByDescending(i => i.ToLower() == "pd").
                              ThenByDescending(i => i.ToLower() == "nc").
                              ThenByDescending(i => i.ToLower() == "na").
                              ThenByDescending(i => i.ToLower() == "new").
                              ThenByDescending(i => i.ToLower() == "pd1").
                              ThenByDescending(i => i.ToLower() == "pd2").
                              ThenByDescending(i => i.ToLower() == "-").
                              ThenByDescending(i => i.ToLower() == "*").
                              ThenBy(i => i.Length).ToList();
            foreach (string rev in revList)
                Console.WriteLine(rev);
            Console.ReadLine();
