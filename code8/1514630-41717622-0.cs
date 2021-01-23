    var orderedDictionary = new SortedDictionary<int, string>();
                orderedDictionary.Add(1, "Abacas");
                orderedDictionary.Add(2, "Lion");
                orderedDictionary.Add(3, "Zebera");
    
                var reverseList = orderedDictionary.ToList().OrderByDescending(pair => pair.Value);
    
                foreach (var item in reverseList)
                {
                    Debug.Print(item.Value);
                }
