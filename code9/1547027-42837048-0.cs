    public static ExpandoObject Create(int id)
    {
        dynamic obj = new ExpandoObject();
        obj.Id = id;
        obj.CreatedAt = DateTime.Now;
        // etc
        return obj;
    } 
