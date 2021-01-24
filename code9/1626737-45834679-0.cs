      public static readonly Func<DBContext, ObjectType, int, Tuple<int, int, int>> GetTotalVotes = CompiledQuery.Compile(
        	(DBContext db, ObjectType forObjectType, int forObjectID) 
       => 
	   db.UserVotes
        .Where(c => c.ForObjectTypeID == (short)forObjectType 
                 && c.ForObjectID == forObjectID)
	    .Select(c => new { c.Upvote, c.ShadowBannedVote })
	    .GroupBy(c => 1)
	    .Select(c => new Tuple<int, int, int>(
	    	c.Count(r => !r.ShadowBannedVote), 
		    c.Count(r => r.Upvote && !r.ShadowBannedVote), 
		    c.Count(r => r.ShadowBannedVote)
	    )).Single());
      
	 
