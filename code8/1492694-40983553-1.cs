	var sumByUser = db.UserIqAnswers.Where(x => x.IqQuestion.CorrectAnswer == x.Answer)
		.GroupBy(x => x.UserId)
		.Select(x => new { userId = x.Key, points = x.Sum(y => y.IqQuestion.Points) });
	var currentUser = sumByUser.Where(x => x.userId == userId).Single();
	var rank = sumByUser.Where(x => x.points > currentUser.points).Count();
