    private string CreatePivotTable(DataTable dt, string[] lines, string[] columns, string[] dimensions, Measure[] measures)
    {
    	var pvtDataFactory = new PivotDataFactory();
    	var pivotData = pvtDataFactory.Create( new PivotDataConfiguration() {
    		Dimensions = dimensions,
    		Aggregators = measures
    			.Select(m => new AggregatorFactoryConfiguration(m.Formula, new[] {m.ColName}) )
    			.ToArray()
    	});
    	// you code that renders HTML pivot table with PivotTableHtmlWriter
    }
