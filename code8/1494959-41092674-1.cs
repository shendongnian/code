	void Main(string[] args)
	{
		var entityQuery = MyEntities.AsExpandable();
	
		var filterGroups = GetFilterGroups();
	
		// Initialize with TRUE since no group filter implies Everything matches
		var predicate = PredicateBuilder.New<MyEntity>(true);
	
		var filteringValueQuery = FilteringValues.AsExpandable();
	
		foreach (var g in filterGroups)
		{
			if (!g.FilterList.Any())
			{
				// If we have no filters in the group, skip
				continue;
			}
			var expressionForGroupFilters = BuildExpressionForGroupFilters(g.FilterList);
			predicate = predicate.And(entity => filteringValueQuery.Any(filteringValue => expressionForGroupFilters.Invoke(entity, filteringValue)));
		}
	
		entityQuery = entityQuery.Where(predicate);
	
		var data = entityQuery.ToList();
		
		data.Dump();
	}
	
	public static Expression<Func<MyEntity, FilteringValue, bool>> BuildExpressionForSingleFilter(Filter groupFilter)
	{
		var value = groupFilter.Value;
		return (entity, filteringValue) =>
			filteringValue.Type == 1
			&& filteringValue.ObjectId == entity.Id
			&& filteringValue.Value == value;
	}
	
	public static Expression<Func<MyEntity, FilteringValue, bool>> BuildExpressionForGroupFilters(IReadOnlyCollection<Filter> groupFilters)
	{
		Expression<Func<MyEntity, FilteringValue, bool>> result = null;
	
		foreach (var groupFilter in groupFilters)
		{
			var expression = BuildExpressionForSingleFilter(groupFilter);
			if (result == null)
			{
				result = expression;
				continue;
			}
			
			var tempResult = result.Expand();
			result = (entity, filteringValue) => tempResult.Invoke(entity, filteringValue) || expression.Invoke(entity, filteringValue);
		}
	
		return result.Expand();
	}
	
	public static FilterGroup CreateFilterGroupWithValues(params int[] values)
	{
		var filterList = values
			.Select(x => new Filter { Value = x })
			.ToList();
	
		return new FilterGroup { FilterList = filterList };
	}
	
	public static IEnumerable<FilterGroup> GetFilterGroups()
	{
		return new[] {CreateFilterGroupWithValues(0, 2, 4), CreateFilterGroupWithValues(1)};
	}
	
	public class Filter
	{
		public int Value { get; set; }
	}
	
	public class FilterGroup
	{
		public FilterGroup()
		{
			FilterList = new List<Filter>();
		}
	
		public List<Filter> FilterList { get; set; }
	}
