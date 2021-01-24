    public interface IHasSSN
    {
    	string SSN { get; set; }
    }
    public class Applicant : IHasSSN
    {
		public string SSN { get; set; }
		// Other properties
    }
    public class OtherTable : IHasSSN
    {
		public string SSN { get; set; }
		// Other properties
    }
    public static Queryable<T> WithSSN<T>(this IQueryable<T> queryable, string ssn) where T : IHasSSN
    {
        return queryable.Where(e => e.SSN == ssn.Trim());
    }
