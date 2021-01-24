    public object Load(int id)
    {
        var rtn = new
        {
            Gender = true,
            Age = 56,
            Weight = 102.4,
            Date = DateTime.Now.AddDays(-7)
        };
        return rtn;
    }
