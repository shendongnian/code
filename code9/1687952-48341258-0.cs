    public bool insert(object model)
    {
        using (_dbInstance) // This works
        {
            //do what ever you want to achieve
            return true;
        }//_dbInstance is disposed
    }
