	void Main()
	{
		var times = new List<Times> {
		new Times
			{
				Start = DateTime.Now,
				End = DateTime.Now.AddMinutes(10)
			},
		new Times
			{
				Start = DateTime.Now,
				End = DateTime.Now.AddMinutes(10)
			},
		new Times
			{
				Start = DateTime.Now.AddMinutes(2),
				End = DateTime.Now.AddMinutes(10)
			},
		new Times
			{
				Start = DateTime.Now.AddMinutes(15),
				End = DateTime.Now.AddMinutes(35)
			},
		new Times
			{
				Start = DateTime.Now.AddMinutes(25),
				End = DateTime.Now.AddMinutes(42)
			},
		new Times
			{
				Start = DateTime.Now.AddMinutes(43),
				End = DateTime.Now.AddMinutes(50)
			},
		new Times
			{
				Start = DateTime.Now.AddMinutes(55),
				End = DateTime.Now.AddMinutes(89)
			},
		new Times
			{
				Start = DateTime.Now.AddMinutes(2),
				End = DateTime.Now.AddMinutes(12)
			}
		};
		var overlaps = times.Select(t1 => times.Count(t2 => IsOverlapping(t1, t2))).Max();
	}
	bool IsOverlapping(Times t1, Times t2)
	{
		if (t1.Start >= t2.Start && t1.Start <= t2.End)
		{
			return true;
		}
		if (t1.End >= t2.Start && t1.End <= t2.End)
		{
			return true;
		}
		if (t2.Start >= t1.Start && t2.Start <= t1.End)
		{
			return true;
		}
		if (t2.End >= t1.Start && t2.End <= t1.End)
		{
			return true;
		}
		return false;
	}
	public class Times
	{
		public DateTime Start { get; set; }
		public DateTime End { get; set; }
	}
