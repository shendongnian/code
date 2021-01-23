    var userName = "john";
    var online = db.Online
    	.Where(o => db.Friend.Any(f => 
    		(f.User1 == o.UserId && f.Users2.Username == userName) ||
    		(f.User2 == o.UserId && f.Users1.Username == userName)))
        .AsEnumerable()
    	.Select(o => new OnlineVM(o))
    	.ToList();
