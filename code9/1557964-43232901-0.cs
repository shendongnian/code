    public bool ExistsLaserData(string article, string kant)
    {
        bool result = false;
        var found = _context.LaserData.Where(x => x.F1 == article || x.Kant == kant).FirstOrDefault();
        if (found != null)
        {
            result = true;
        }
    
        return result;
    }
