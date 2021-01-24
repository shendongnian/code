    List<T> GetRandomElements<T>(List<T> allElements, int randomCount = 4)
    {
        if (allElements.Count < randomCount)
        {
            return allElements;
        }
        List<int> indexes = new List<int>();
        // use HashSet if performance is very critical and you need a lot of indexes
        //HashSet<int> indexes = new HashSet<int>(); 
        List<T> elements = new List<T>();
    
        Random random = new Random(); 
        while (indexes.Count < randomCount)
        {
            int index = random.Next(allElements.Count);
            if (!indexes.Contains(index))
            {
                indexes.Add(index);
                elements.Add(allElements[index]);
            }
        }
        return elements;
    }
