	void Main()
	{
		var filters = new Filters();
		var topsalesQueryable = new List<TopItemReportData>();
		var TopItemReportData = new List<TopItemReportData>();
		IEnumerable<IGrouping<String, TopItemReportData>> tempGroupedData;
		
		var dateBy = filters.DateBy.ToLower().Replace(" ", "");
		var groupBy = filters.GroupBy.ToLower().Replace(" ", "");
		
	
		if ( dateBy  == "yearlyreport")
		{
			if (groupBy ==  "product")
				tempGroupedData = TopItemReportData
                                   .GroupBy(x =>string.Format("{0:0000}|{1:000000}",
                                             x.SalesDate.Year, x.ProductId));
			else
			   tempGroupedData = TopItemReportData.GroupBy(x => x.SalesDate.Year.ToString());
		}
		else if (dateBy == "monthlyreport")
			tempGroupedData = topsalesQueryable.GroupBy(x => x.SalesDate.Month.ToString());
		else
			tempGroupedData = topsalesQueryable.GroupBy(x => x.SalesDate.Date.ToString());
		
		if (groupBy == "variantoption")
			tempGroupedData = topsalesQueryable.GroupBy(x => x.VariantId.ToString());
		else if (groupBy == "product")
			tempGroupedData = topsalesQueryable.GroupBy(x => x.ProductId.ToString());
			
		var GroupedData = tempGroupedData
                                .OrderByDescending(x => x.Sum(y => y.SellingQuantity))
					 			.Skip((filters.CurrentPage - 1) * filters.RecordsPerPage)
								.Take(filters.RecordsPerPage)
								.ToList();
	}
	
	class Filters
	{
		public string DateBy;
		public string GroupBy;
		public int CurrentPage;
		public int RecordsPerPage;
		
		public Filters()
		{
			DateBy = "Yearly Report";
			GroupBy = "variantoption";
		}
		
	}
	
	class TopItemReportData
	{
		public DateTime SalesDate;
		public int SellingQuantity;
		public int VariantId;
		public int ProductId;
	}
