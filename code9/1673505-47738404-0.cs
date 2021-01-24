    public static T[] Categorize<T>(this T[] data, string extensions[])
    {
        //using List to make copying easier
        List<T> result = new List<T>();
        
        foreach(string extension in extensions)
        {    
            var filteredData = (from item in data
                                where Path.GetExtension(item) == extension
                                select item)
            result.AddRange(filteredData);
        }
    
        return result.ToArray();
    }
