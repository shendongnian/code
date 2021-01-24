    List<T> GetFourRandomElements<T>(List<T> allElements, int randomCount = 4)
    {
        if (allElements.Count < randomCount)
        {
            return allElements;
        }
        List<int> indexes = new List<int>();
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
