    public Task<int> GetLatestUserId ()
    {
        var resultTask = db.Users.Select(u => u.Id).OrderByDesc(id => id).FirstAsync();
        return resultTask;
    }
