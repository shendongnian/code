	[Table("EMPLOYMENT")]
	public class Employment : EntityBase
	{   
		DateTime? startDate;
		
		[Column("STARTDATE")]
		public DateTime? StartDate
		{
			get { return this.startDate; }
			set
			{
				this.startDate = value;
				this.StartMonth = value.HasValue ? value.Value.ToString("MMMM") : null;
			}
		}
		[Column("STARTMONTH")]
		public string StartMonth { get; private set; }
	}
