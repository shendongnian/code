		static void Main(string[] args)
		{
			// Add new employees
			while(true)
			{
				Console.WriteLine("Please enter employee name: ");
				var employeeName = Console.ReadLine();
				if (string.IsNullOrWhiteSpace(employeeName))
					break;
				var employee = new Employee(employeeName);
				// Add employee hours
				while(true)
				{
					Console.WriteLine("Please enter hours worked: ");
					var inputHours = Console.ReadLine();
					if (string.IsNullOrWhiteSpace(inputHours))
					{
						Console.WriteLine("Name: {0}\nHours worked: {1}", employee.Name, employee.HoursWorked.Sum());
						break;
					}
					var hours = float.Parse(inputHours);
					if (hours > 0)
					{
						employee.HoursWorked.Add(hours);
						Console.WriteLine("Hours added");
					}
					else
					{
						Console.WriteLine("Please enter valid hours");
					}
				}
			}
	
		}
		public class Employee
		{
			private readonly string _name;
			public Employee(string name)
			{
				_name = name;
				HoursWorked = new List<float>();
			}
			public string Name
			{
				get { return this._name; }
			}
			public List<float> HoursWorked { get; set; }
		}
