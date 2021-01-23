	db.Set<MediaPlanPrint>()
		.Include(m => m.MediaPlanRoDetails)	
		// Filter according to BillId
		.Where(m => m.MediaPlanRoDetails.MediaPlanRo.MediaPlanBillingDetails.BillId < 100)
		// Group by RoId
		.GroupBy(m => m.MediaPlanRoDetails.RoId)
		.Select(g => new
		{
			RoId = g.Key,
			TotalAmount = g.Sum(m => m.Amount)
		})
		.ToList();
