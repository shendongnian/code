    private int getUserPoints(string nickname)
    {
        using (linkToSqlClassDataContext db = new linkToSqlClassDataContext(Properties.Settings.Default.pointsGambleConnectionString))
        {
            var p = from r in db.USERs
                    where r.USER1 == nickname
                    select r.POINTS;
            return p.FirstOrDefault();
        }
    }
