    public string GetObjectTypeName(object something)
    {
        if(something==null)
            throw new Exception("Some Exception Message");
        return something.GetType().Name;
    } 
