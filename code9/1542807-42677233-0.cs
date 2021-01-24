            List<string> myList = new List<string> { "Item1", "Item2", "Item3", "Item4" };
            List<string> newList = new List<string>();
            for (var index = 1; index <= myList.Count(); index++)
            {
                newList.Add(string.Join("/", myList.Take(index)));
            }
