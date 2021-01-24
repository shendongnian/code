    public Setting GetSetting()
    {
        try
        {
            return _db.Settings.First();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
