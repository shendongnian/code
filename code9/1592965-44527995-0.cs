    private RowsFilter m_rowsFilter;
    private void CreateFilter()
	{
		CustomComparisonCondition c = new CustomComparisonCondition();
		var predicate = PredicateBuilder.False<LineRatingNodeComparison>();
		foreach (string colKey in MyXamGrid.Columns.Where(co => co.DataType == typeof (decimal?) && co.Visibility == Visibility.Visible).Select(co => co.Key))
		{
			string tempKey = colKey;
			predicate = predicate.Or(p => p.GetPropValue(tempKey) != null && (decimal?) p.GetPropValue(tempKey) != 0.0m);
		}
		c.Expression = predicate;
        //Add the RowsFilter to one column that always exists on the grid.
		m_rowsFilter = new RowsFilter(typeof (MyObject), MyXamGrid.Columns.DataColumns["Company"]);
		m_rowsFilter.Conditions.Add(c);
		MyXamGrid.FilteringSettings.RowFiltersCollection.Add(m_rowsFilter);
	}
