    public object MyCall(string dvprid)
    {
        return new
        {
            options = new
            {
                logan_dvprTasks = GetAllItems(dvprid)
            };
        };
    }
