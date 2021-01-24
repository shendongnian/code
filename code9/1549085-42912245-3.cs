          IEnumerable<Planet> myCollection = new List<Planet>();
          myCollection = LetThereBeLight(true); //method to populate the list
          var myList = myCollection.ToList().Where(t => t.Name.ToUpper().Contains("M"));
          myList.ToList().AddRange
                                (
                                 myCollection.SelectMany(t => t.Children.Where
                                        (
                                          v => v.Name.ToUpper().Contains("M")).Distinct()
                                        )
                                );
