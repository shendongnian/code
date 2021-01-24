	public Coverage CreateCoverageSessionIsolated(string description, out bool isNew)
	{
		Coverage coverage = null;
		bool _isNew = false;
		this.ExecuteOnNewSession((session) =>
		{
			this.semphoresDao.LockSemaphore(session, "SMF_COVERAGES");
			coverage = session.QueryOver<Coverage>()
				.Where(g => g.Description == description)
				.Take(1) 
				.SingleOrDefault();
			_isNew = coverage == null;
			if (coverage == null)
			{
				coverage = new Coverage { Description = description };
				this.Save(coverage);
			}
		});
		isNew = _isNew;
		return coverage;
	}
