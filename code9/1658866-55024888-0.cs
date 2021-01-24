    public IQueryable<ApplicationUser> SelectNearByUser()
    {
        var query = "execute dbo.GetCouffierSearch";
        var res = _context.Users.FromSql(query);
        _context.Entry(res)
                .Collection(x => x.CoiffeurServiceLevels)
                .Load();
        return res;
    }
