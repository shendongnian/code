    public DateTime StartDate
    {
    	get { return new DateTime(_startYear, 4, 1); } // April 1st
    }
    public static FinancialYear ForDate(DateTime dt)
    {
    	DateTime finYearStart = new DateTime(dt.Year, 4, 1);
    	return (dt >= finYearStart) ? new FinancialYear(dt.Year) : new FinancialYear(dt.Year - 1);
    }
