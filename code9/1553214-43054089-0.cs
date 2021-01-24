	[Table("EMPLOYMENT")]
	public class Employment : EntityBase
	{   
		[Column("STARTDATE")]
		public DateTime? StartDate { get; private set; }
		[Column("STARTMONTH")]
		public string StartMonth { get; private set; }
		
		public string SetStartDate(DateTime? startDate)
		{
			this.StartDate = startDate;
			this.StartMonth = startDate.HasValue ? startDate.Value.ToString("MMMM") : null;
		}
	}
