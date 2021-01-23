    var specs = new Specs[]
    {
        new Specs{specId = 1, desc = "Spec1", createdby=1, lastupdatedby=1},
        new Specs{specId = 2, desc = "Spec2", createdby=2, lastupdatedby=3},	
        new Specs{specId = 3, desc = "Spec3", createdby=3, lastupdatedby=1},
        new Specs{specId = 4, desc = "Spec4", createdby=3, lastupdatedby=3},
    };
    var user = new Users[]
    {
        new Users{userId = 1, username = "User1"},
        new Users{userId = 2, username = "User2"},
    };
	
    var updatedUser = new UpdatedUser[]
    {
        new UpdatedUser{userId = 1, username = "UpdatedUser1"},
        new UpdatedUser{userId = 2, username = "UpdatedUser2"},			
    };
    var result = specs
        .GroupJoin(user, 
            s => s.createdby,
            u => u.userId,
	    (s, u) => u.Select(x => new {spec = s, user = x})
                .DefaultIfEmpty(new {spec = s, user = (Users)null}))
	.SelectMany(g => g)
	.GroupJoin(updatedUser,
            firstJoin => firstJoin.spec.lastupdatedby,
            uu => uu.userId,
            (firstJoin, uu) => 
	        uu.Select(y => new {spec = firstJoin.spec, user = firstJoin.user, updatedUser = y})
	.DefaultIfEmpty(new {spec = firstJoin.spec, user = firstJoin.user, updatedUser = (UpdatedUser) null}))
        .SelectMany(g1 => g1)
        .ToList();
