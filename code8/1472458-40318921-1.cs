    public static int getNextId(List<IdHolder>param)
    {
        int lastId = param[param.Count - 1].Id;
        if (lastId!=0)
        {
            return lastId++;
        }
        return 0;
    }    
