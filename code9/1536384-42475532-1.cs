	public class Employee {
		IEmployeeRepository repository;
		
		public int EmployeeId { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public int Age { get; set; }
		public int phoneNumber { get; set; }
		public Employee() {
		}
		public Employee(string fname, string lname, int age, int phone) {
			this.FirstName = fname;
			this.LastName = lname;
			this.Age = age;
			this.phoneNumber = phone;
		}
		public void InsertEmployee() {
			repository.Add(this);
		}
		public List<Employee> GetAllEmployees() {
			return repository.GetAll();
		}
		public void SetRepository(IEmployeeRepository repository) {
			this.repository = repository;
		}
	}
	
