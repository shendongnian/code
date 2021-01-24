    // A class to hold all the possible conditions applied for the report
    // Can be applied at various levels within the select
    public class WhereConditions
    {
	    public string CancelledFlag { get; set; } = "0";  // <= default setting
	    public DateTime StartTime { get; set; }
	    public DateTime EndTime { get; set; }
    }
    // Class to define all the filters to be applied to any level of table
    public static class QueryExtensions
    {
	    public static IQueryable<BaseTable> ApplyCancellationFilter(this IQueryable<BaseTable> base, WhereConditions clause)
	    {
		    return base.Where(bse => bse.CancelFlag.Equals(clause.CancelledFlag));
	    }
	    public static IQueryable<BaseTable> ApplyTimeFilter(this IQueryable<BaseTable> base, WhereConditions clause)
	    {
		    return base.Where(bse => bse.TimeStamp.CompareTo(clause.StartTime) > 0 &&
								     bse.TimeStamp.CompareTo(clause.EndTime) < 1);
	    }
    }
