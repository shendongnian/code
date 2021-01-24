	public List<CCOPTG> listrecentCCOPTG()
	{
		datetime startdate = DateTime.Today.AddDays(-7);
		datetime enddate = DateTime.Now;
		return db.CCOPTG.Where
			(p => p.TG003>=startdate && p.TG003 <= enddate)
			.OrderByDescending(p=>p.TG003).ToList();
	}
