	public class WorkItemViewModel
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string AssignedTo { get; set; }
		public string WorkitemType { get; set; }
		public string Priorty { get; set; }
		public string IterationPath { get; set; }
		public string State { get; set; }
		public List<TFSIssue> Issues { get; set; }
		public List<TFSTask> Tasks { get; set; }
		public List<Backlogitem> PBacklog { get; set;}
		
		public WorkItemViewModel()	// Added a public constructor
		{
			Issues = new List<TFSIssue>();
			Tasks = new List<TFSTask>();
			PBacklog =  new List<Backlogitem>();
		}
	}
