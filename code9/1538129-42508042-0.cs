    public class TimeBlock
	{
		public DateTime EndTime {get;set;}
		public DateTime StartTime {get;set;}
		public bool OverlapsWith(TimeBlock other)
		{
		    return (StartTime <= other.StartTime && EndTime >= other.StartTime)
		        || (StartTime <= other.EndTime && EndTime >= other.EndTime);
		}
	}
