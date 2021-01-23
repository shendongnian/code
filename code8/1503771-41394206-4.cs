    // Step 1 : Get the right reviews
	var matches = this.Reviews.GroupBy(r => r.RestaurantId, r => this.Reviews.Where(rr => rr.UserId == r.UserId)).ToList()
	.Where(g => g.Where(gg => gg.Count() >= 2).Count() >= 3);
	
	var matchingReviewsByRestaurant = matches.ToDictionary(m => m.Key, m => m.Where(g => g.Count() >= 2).SelectMany(g => g));
	
	// Step 2 : Create the matching couples
	var reviewsByUsers = matchingReviewsByRestaurant.SelectMany(m => m.Value).Distinct().ToLookup(r => r.UserId);
	
	var matchingReviewsCouples = new List<Match>();
		
	foreach (var reviews in reviewsByUsers)
	{
		var combinations = reviews.SelectMany(x => reviews, (x, y) => new Match(x, y))
								  .Where(m => m.Review1.Id.CompareTo(m.Review2.Id) > 0)
					   		      .ToList();
		matchingReviewsCouples.AddRange(combinations);
	}
	// Final Results are in matchingReviewsCouples
