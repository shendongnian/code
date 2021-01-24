          IEnumerable<Planet> myCollection = new List<Planet>();
                var myList = myCollection.ToList().Where(t => t.Name.ToUpper().Contains("M"));
                myList.ToList().AddRange
                                (
                                 myList.SelectMany(t => t.Children.Where
                                        (
                                          v => v.Name.ToUpper().Contains("M")).Distinct()
                                        )
                                );
