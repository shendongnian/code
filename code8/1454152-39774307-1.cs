    public static class DateProjections
    {
    	private const string DateDiffFormat = "datediff({0}, ?1, ?2)";
    
    	// Maps datepart to an ISQLFunction
    	private static Dictionary<string, ISQLFunction> DateDiffFunctionCache = new Dictionary<string, ISQLFunction>();
    
    	public static IProjection DateDiff(string datepart, IProjection startDate, DateTime? endDate)
    	{
    		ISQLFunction sqlFunction = GetDateDiffFunction(datepart);
    
    		return Projections.SqlFunction(
    			sqlFunction,
    			NHibernateUtil.Int32,
    			startDate,
    			Projections.Constant(endDate));
    	}
       
    	//Get exact age of a person as of today
    	public static IProjection Age(string datepart, IProjection startDate, DateTime? endDate)
    	{
    		IProjection myAge = DateDiff("yy",
    			startDate, endDate);
    
    		IProjection ageMinusOne = Projections.SqlFunction(
    			new VarArgsSQLFunction("(", "-", ")"), NHibernateUtil.Int32, myAge,
    			Projections.Constant(1));
    
    		IProjection datePartMonthBirthdate = Projections.SqlFunction("month", NHibernateUtil.Int32,
    			startDate);
    
    		IProjection datePartDayBirthdate = Projections.SqlFunction("day", NHibernateUtil.Int32,
    			startDate);
    
    		IProjection datePartMonthCurrentDate = Projections.SqlFunction("month", NHibernateUtil.Int32,
    			Projections.Constant(endDate));
    
    		IProjection datePartDayCurrentDate = Projections.SqlFunction("day", NHibernateUtil.Int32,
    			Projections.Constant(endDate));
    
    		IProjection myRealAge = Projections.Conditional(
    								Restrictions.Or(
    									Restrictions.GtProperty(datePartMonthBirthdate, datePartMonthCurrentDate),
    									Restrictions.GtProperty(datePartDayBirthdate, datePartDayCurrentDate)
    									&& Restrictions.EqProperty(datePartMonthBirthdate, datePartMonthCurrentDate)),
    								ageMinusOne,
    								myAge);
    		return myRealAge;
    	}
    
    	private static ISQLFunction GetDateDiffFunction(string datepart)
    	{
    		ISQLFunction sqlFunction;
    
    		if (!DateDiffFunctionCache.TryGetValue(datepart, out sqlFunction))
    		{
    			string functionTemplate = string.Format(DateDiffFormat, datepart);
    			sqlFunction = new SQLFunctionTemplate(NHibernateUtil.Int32, functionTemplate);
    
    			DateDiffFunctionCache[datepart] = sqlFunction;
    		}
    		return sqlFunction;
    	}
    }
