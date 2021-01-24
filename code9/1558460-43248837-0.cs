    public void loopProp<T>(IEnumerable<T> source, PropertyInfo[] properites, List<string> addedValues)
    {           
        foreach (var qrl in source)
        {
            // ...
        }
        File.WriteAllLines("my_passed_data.txt", addedValues);
    }
