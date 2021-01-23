	public class Employment
	{
		[Required, StringLength(50, MinimumLength = 3, ErrorMessage ="Name must    be between 3 and 50 characters long.")]
		public string Name { get; set; }
		private string _emplyomentNumber;
        private decimal _salary;
		public EmploymentType EmpType { get; set; }
		public string EmplyomentNumber 
		{ 
		    get { return _emplyomentNumber; }
		    set
			{    
			    // validate here!
			    _emplyomentNumber = value;
			}
        }
 
		public decimal Salary 
		{ 
			get { return _salary; } 
			set
			{
			    // validate here!
			    _salary = value;
			}
        }
	}
	public enum EmploymentType
	{
		Full,
		Temporary,
		Internship
	}
