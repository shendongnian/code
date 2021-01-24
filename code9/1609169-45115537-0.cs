    private string CreatePivotTable(
        DataTable dt, string[] lines, string[] columns, string[] dimensions, Measure[] measures)
    {
    	var aggrFactories = new List<IAggregatorFactory>();
    	foreach(var m in measures) {
    		if (m.Formula.equals("sum"))
    			aggrFactories.Add( new SumAggregatorFactory(m.ColName));
    		else if(m.Formula.equals("avg")){
    			aggrFactories.Add( new AverageAggregatorFactory(m.ColName));
    		}
    	}
    	if (aggrFactories.Length==0) {
    		// no measures provided. 
    		// Throw an exception or configure "default" measure (say, CountAggregatorFactory)
    		aggrFactories.Add( new CountAggregatorFactory() );
    	}	
    	var pivotData = new PivotData(dimensions, 
    		aggrFactories.Length==1 ? aggrFactories[0] : new CompositeAggregatorFactory(aggrFactories.ToArray()),
    		new DataTableReader(dt));
    	// you code that renders HTML pivot table with PivotTableHtmlWriter
    }
