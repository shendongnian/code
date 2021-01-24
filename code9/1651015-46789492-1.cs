	foreach (var x in query)
	{
		entitiesFound.AddRange(x.matchingRows.Select(y => y.entity));
		if (x.matchingRows.Count() == 0)
		{
			rowsToAdd.Add(x.input.record);
		}
		else if (x.matchingRows.Count() == 1)
		{
			if (x.matchingRows.First().bombOutTerm != x.input.bombOutTerm)
			{
				rowsToUpdate.Add(x.input.record);
				entitiesToUpdate.Add(x.matchingRows.First().entity);
			}
		}
		else
		{
			entitiesToDelete.AddRange(x.matchingRows.Select(y => y.entity));
			rowsToAdd.Add(x.input.record);
		}
	}
