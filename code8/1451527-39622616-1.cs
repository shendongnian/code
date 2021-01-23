    var user = new List<UserWatchTblCls>();
    var cursor = collectionWatchtbl.FindAsync(filter).Result;
    cursor.ForEachAsync(batch =>
    {
        user.Add(new UserWatchTblCls()
        {
            Id = ObjectId.Parse(batch["_id"].ToString()),
            Name = batch["Name"].ToString()
        });
    });
