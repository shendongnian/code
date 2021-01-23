    public static async Task<int> GetUsersRank(DbEntities db, string userId)
    {
    	var userPoints = await db.UserIqAnswers
    		.Where(x => x.UserId == userId && x.IqQuestion.CorrectAnswer == x.Answer)
    		.SumAsync(x => (decimal?)x.IqQuestion.Points) ?? 0;
    	var rank = await db.UserIqAnswers
    		.Select(x => new { x.UserId, x.Answer, x.IqQuestion })
    		.Where(x => x.UserId != userId && x.IqQuestion.CorrectAnswer == x.Answer)
    		.GroupBy(x => x.UserId)
    		.Select(x => new { userId = x.Key, points = x.Sum(y => y.IqQuestion.Points) })
    		.CountAsync(x => x.points < userPoints || (x.points == userPoints && string.Compare(x.userId, userId) < 0));
    	return rank;
    }
