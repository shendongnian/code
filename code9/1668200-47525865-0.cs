    public List<tableName> CheckAccessCodesFor_Common(DBContext db)
    {
        var dbrc = db.View.ToList();
        return dbrc;
    }
