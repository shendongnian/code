	private abstract class Operation
	{
		public string TaskType;
		public string PropertyName;
		public Action<double> Incremement;
	
		public abstract void Update(long aid);
	}
	
	private class BugOperation : Operation
	{
		public IEnumerable<Bug> Source;
		public Func<Bug, double?> Select;
	
		public override void Update(long aid)
		{
			this.Incremement(
				this.Source
					.Where(x => x.Aid == aid)
					.Select(this.Select)
					.FirstOrDefault() ?? 0);
		}
	}
	
	private class BugTaskOperation : Operation
	{
		public IEnumerable<BugTask> Source;
		public Func<BugTask, double?> Select;
	
		public override void Update(long aid)
		{
			this.Incremement(
				this.Source
					.Where(x => x.Aid == aid)
					.Select(this.Select)
					.FirstOrDefault() ?? 0);
		}
	}
