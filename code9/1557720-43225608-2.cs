	bool IsOverlapping(Times t1, Times t2)
	{
		return t1.Contains(t2.Start) || t1.Contains(t2.End) || t2.Contains(t1.Start) || t2.Contains(t1.End);
	}
	public class Times
	{
		public DateTime Start { get; set; }
		public DateTime End { get; set; }
		public bool Contains(DateTime date)
		{
			return date >= Start && date <= End;
		}
	}
