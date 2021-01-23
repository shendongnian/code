    public static int returnId(object input)
    {        
        if(input != null)
        {
            var Id = (int?)input.GetType().GetProperty("Id").GetValue(input);
            if(Id != null)
                return Id;
        }
        return 0;
    }
