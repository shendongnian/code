    public static int returnId(object input)
    {        
        if(input != null)
        {
            var Id = input.GetType().GetProperty("Id").GetValue(input);
            if(Id != null)
                return ((int?)Id).Value;
        }
        return 0;
    }
