    public void Filter(string column, string value)
    {
        var data = new InfoCollection().Data;
    
        //get the column to filter
        PropertyInfo property = data[0].GetType().GetProperty(column);
        
        //filter getting dinamically the column
        var result = data.Where(x => property.GetValue(x, null) == value);
    
        Console.WriteLine(result);
    }
