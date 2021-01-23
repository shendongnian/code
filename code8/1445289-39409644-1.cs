    private void GetMyData(List<T> the List)
    {
        foreach (T entry in theList)
        {
            foreach (var property in typeof(T).GetProperties())
            {
                var propertyName = property.Name;
                var propertyValue = property.GetValue(entry);
                Console.WriteLine("Value of " + propertyName + " is " + propertyValue);
            }
        }
    }
