	// Add or update each Child Detail from the View Model
	foreach (var childDetailViewModel in callDetailsViewModel.ParentRecordViewModel
		.ChildDetailViewModels)
	{
		// Map the Child Detail View Model to a Model
		var childDetail =
			Mapper.Map<ChildDetail>(childDetailViewModel);
		// Set the ParentRecord_Id property, since that doesn't get mapped
		childDetail.ParentRecord_Id = parentRecord.Id;
		// Delete those that are null or whitespace
		if (childDetail.Value.IsNullOrWhiteSpace())
		{
			context.Entry(childDetail).State = EntityState.Deleted;
			continue;
		}
		// Add or update each Child Detail
		context.ChildDetails.AddOrUpdate(childDetail);
	}
    
	// For each contextChildDetail in the context, where they have matching Parent Record Id...
	foreach (var contextChildDetail in context.ChildDetail.Where(x => x.ParentRecord_Id == parentRecord.Id))
	{
		// ... and if we can't find it in the ViewModel list, then delete it
		if (callDetailsViewModel.ParentRecordViewModel.ChildDetailViewModels.FirstOrDefault(
				x => x.Id == contextChildDetail.Id) == null)
		{
			context.ChildDetail.Remove(contextChildDetail);
		}
	}
