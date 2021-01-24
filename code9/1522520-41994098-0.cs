	public class SkillVM // represents a table cell
	{
		public int ID { get; set; }
		public bool IsSelected { get; set; }
	}
	public class EmployeeVM // table row
	{
		public int ID { get; set; }
		public string Name { get; set; }
		public List<SkillVM> Skills { get; set; } // columns
	}
	public class EmployeeSkillVM // represents the table
	{
        public int ID { get; set; }
        public string Date { get; set; }
		public IEnumerable<string> SkillList { get; set; } // table headings
		public List<EmployeeVM> Employees { get; set; } // table rows
	}
