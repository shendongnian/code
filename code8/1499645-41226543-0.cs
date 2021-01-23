	dtLists.AsEnumerable()
		.Select(row => new {
		   SearchCategoryId = row.Field<int>("ListID "),
		   SearchCategoryName = row.Field<string>("listName"),
		   TagValue = row.Field<string>("TagValue")
		})
		.GroupBy(x => x.SearchCategoryId)
		.Select(g => new SearchCategories() {
					SearchCategoryId  = g.Key,
					SearchCategoryName = g.First().SearchCategoryName,
					lstSubCategories = g.Select(x => new SearchTags(x)).ToList()
					}).ToList();
